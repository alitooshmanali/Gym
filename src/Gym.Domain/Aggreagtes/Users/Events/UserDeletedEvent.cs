using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserDeletedEvent : BaseDomainEvent
{
    public UserDeletedEvent(UserId id, Guid deleterId)
        : base(id.Value)
    {
        DeleterId = deleterId;
    }

    public Guid DeleterId { get; }
}