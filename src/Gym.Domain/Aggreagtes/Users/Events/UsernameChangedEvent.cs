using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UsernameChangedEvent : BaseDomainEvent
{
    public UsernameChangedEvent(UserId id, Username oldValue, Username newValue)
        : base(id.Value)
    {
        OldValue = oldValue.Value;
        NewValue = newValue.Value;
    }

    public string NewValue { get; }

    public string OldValue { get; }
}