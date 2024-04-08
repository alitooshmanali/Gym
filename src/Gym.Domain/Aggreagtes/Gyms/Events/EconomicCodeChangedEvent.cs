using Gym.Domain.Aggregates.Gyms.ValueObjects;

namespace Gym.Domain.Aggregates.Gyms.Events;

public class EconomicCodeChangedEvent: BaseDomainEvent
{
    public EconomicCodeChangedEvent(GymId id, EconomicCode oldValue, EconomicCode newValue, Guid updaterId) 
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