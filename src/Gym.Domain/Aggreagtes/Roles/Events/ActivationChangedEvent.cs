using Gym.Domain.Aggregates.Roles.ValueObjects;

namespace Gym.Domain.Aggregates.Roles.Events;

public class ActivationChangedEvent: BaseDomainEvent
{
    public ActivationChangedEvent(RoleId id, RoleActivation oldValue, RoleActivation newValue, Guid updaterId) 
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