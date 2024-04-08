using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.Aggregates.Roles.Events;

public class RoleCreatedEvent : BaseDomainEvent
{
    public RoleCreatedEvent(RoleId id, Name name, RoleActivation isActive, Guid creatorId)
        : base(id.Value)
    {
        Name = name.Value;
        IsActive = isActive.Value;
        CreatorId = creatorId;
    }

    public Guid CreatorId { get; }

    public bool IsActive { get; }

    public string Name { get; }
}