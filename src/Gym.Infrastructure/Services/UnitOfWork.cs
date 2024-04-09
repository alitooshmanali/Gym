using Gym.Application;
using Gym.Domain;
using Gym.Infrastructure.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infrastructure.Services;

public class UnitOfWork: IUnitOfWork
{
    private readonly GymWriteDbContext _dbContext;

    private readonly IMediator _mediator;

    private readonly IUserDescriptor _userDescriptor;

    private readonly ISystemDateTime _systemDateTime;

    public UnitOfWork(GymWriteDbContext dbContext
    , IMediator mediator
    , IUserDescriptor userDescriptor
    , ISystemDateTime systemDateTime)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _userDescriptor = userDescriptor;
        _systemDateTime = systemDateTime;
    }

    public Task BeginTransaction(CancellationToken cancellationToken = default)
        => _dbContext.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitTransaction(CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents(cancellationToken).ConfigureAwait(false);
        await _dbContext.Database.CommitTransactionAsync(cancellationToken).ConfigureAwait(false);
        await _mediator.Publish(new EntitiesPersistedNotification(), cancellationToken).ConfigureAwait(false);
    }

    public Task RollbackTransaction(CancellationToken cancellationToken = default)
        => _dbContext.Database.RollbackTransactionAsync(cancellationToken);

    private async Task PublishDomainEvents(CancellationToken cancellationToken)
    {
        while (true)
        {
            var entries = _dbContext.ChangeTracker.Entries<Entity>().ToList();

            if (entries.Any(i => i.State == EntityState.Deleted && !i.Entity.CanBeDeleted()))
                throw new InvalidOperationException();

            SetAuditingProperties();

            var domainEvents = entries
                .Where(i => i.Entity.DomainEvents.Any())
                .SelectMany(i => i.Entity.DomainEvents)
                .ToArray();

            entries.ForEach(i=> i.Entity.ClearEvents());
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if(!domainEvents.Any())
                break;

            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(new DomainEventsPublishedNotification(), cancellationToken)
                    .ConfigureAwait(false);
        }

        await _mediator.Publish(new DomainEventsPublishedNotification(), cancellationToken).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private void SetAuditingProperties()
    {
        var entries = _dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(i => i.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in entries)
        {
            var versionProperty = entry.Property("Version");
            versionProperty.CurrentValue = (int)(versionProperty.OriginalValue ?? 0) + 1;

            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatorId").CurrentValue = _userDescriptor.GetId();
                entry.Property("Created").CurrentValue = _systemDateTime.UtcNow;
            }

            if (entry.State != EntityState.Modified)
                continue;

            entry.Property("UpdaterId").CurrentValue = _userDescriptor.GetId();
            entry.Property("Updated").CurrentValue = _systemDateTime.UtcNow;
        }
    }
}