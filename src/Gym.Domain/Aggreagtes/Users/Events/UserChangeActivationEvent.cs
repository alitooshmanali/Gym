using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserChangeActivationEvent : BaseDomainEvent
{
    public UserChangeActivationEvent(UserId id, UserActivation oldValue, UserActivation newValue)
        : base(id.Value)
    {
        OldValue = oldValue.Value;
        NewValue = newValue.Value;
    }

    public bool NewValue { get; }

    public bool OldValue { get; }
}