using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UsernameChangedEvent : BaseDomainEvent
{
    public UsernameChangedEvent(UserId id, Username oldValue, Username newValue, Guid updaterId)
        : base(id.Value)
    {
        OldValue = oldValue.Value;
        NewValue = newValue.Value;
        UpdaterId = updaterId;
    }

    public Guid UpdaterId { get; }

    public string NewValue { get; }

    public string OldValue { get; }
}