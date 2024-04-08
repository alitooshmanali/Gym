using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserChangeActivationEvent : BaseDomainEvent
{
    public UserChangeActivationEvent(UserId id, UserActivation oldValue, UserActivation newValue, Guid updaterId)
        : base(id.Value)
    {
        OldValue = oldValue.Value;
        NewValue = newValue.Value;
        UpdaterId = updaterId;
    }

    public Guid UpdaterId { get; }

    public bool NewValue { get; }

    public bool OldValue { get; }
}