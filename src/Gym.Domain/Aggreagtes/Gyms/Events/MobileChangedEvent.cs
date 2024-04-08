using Gym.Domain.Aggregates.Gyms.ValueObjects;

namespace Gym.Domain.Aggregates.Gyms.Events;

public class MobileChangedEvent : BaseDomainEvent
{
    public MobileChangedEvent(GymId id, Mobile oldValue, Mobile newValue, Guid updaterId)
        : base(id.Value)
    {
        OldValue = oldValue.Value;
        NewValue = newValue.Value;
        UpdaterId = updaterId;
    }

    public string OldValue { get; }

    public string NewValue { get; }

    public Guid UpdaterId { get; }
}