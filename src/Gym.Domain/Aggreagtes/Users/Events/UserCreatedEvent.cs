using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserCreatedEvent : BaseDomainEvent
{
    public UserCreatedEvent(UserId id, Username username, Guid creatorId)
        : base(id.Value)
    {
        Username = username.Value;
        CreatorId = creatorId;
    }

    public string Username { get; }

    public Guid CreatorId { get; }
}