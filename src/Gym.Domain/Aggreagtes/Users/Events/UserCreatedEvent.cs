using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserCreatedEvent : BaseDomainEvent
{
    public UserCreatedEvent(UserId id, Username username)
        : base(id.Value)
    {
        Username = username.Value;
    }

    public string Username { get; }
}