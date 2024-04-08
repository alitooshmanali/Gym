using Gym.Domain.Aggregates.Gyms.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.Aggregates.Gyms.Events;

public class GymDescriptionChangedEvent : BaseDomainEvent
{
    public GymDescriptionChangedEvent(GymId id, Description oldValue, Description newValue, Guid updaterId)
        : base(id.Value)
    {
        OldValue = oldValue?.Value;
        NewValue = newValue?.Value;
        UpdaterId = updaterId;
    }

    public Guid UpdaterId { get; }

    public string? NewValue { get; }

    public string OldValue { get; }
}