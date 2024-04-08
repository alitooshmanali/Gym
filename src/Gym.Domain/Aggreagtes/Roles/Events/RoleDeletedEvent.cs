using Gym.Domain.Aggregates.Roles.ValueObjects;

namespace Gym.Domain.Aggregates.Roles.Events;

public class RoleDeletedEvent : BaseDomainEvent
{
    public RoleDeletedEvent(RoleId id, Guid deleterId)
        : base(id.Value)
    {
        DeleterId = deleterId;
    }

    public Guid DeleterId { get; }
}