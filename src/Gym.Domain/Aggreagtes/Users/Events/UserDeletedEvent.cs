using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserDeletedEvent : BaseDomainEvent
{
    public UserDeletedEvent(UserId id)
        : base(id.Value)
    {
    }
}