using Gym.Domain.Exceptions;

namespace Gym.Domain;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents;

    private bool _canBeDeleted;

    protected Entity()
    {
        _domainEvents = new List<IDomainEvent>();
    }

    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public bool CanBeDeleted() => _canBeDeleted;

    public void ClearEvents() => _domainEvents.Clear();

    protected void AddEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    protected void MarkAsDeleted() => _canBeDeleted = true;

    protected static void CheckRule(IBusinessRule rule)
    {
        if (!rule.IsBroken())
            return;

        throw new DomainException(rule.Message);
    }
}