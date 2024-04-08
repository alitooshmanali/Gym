using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.Aggregates.Roles.Events;

public class NameChangedEvent : BaseDomainEvent
{
    public NameChangedEvent(RoleId id, Name oldValue, Name newValue, Guid updaterId)
        : base(id.Value)
    {
        OldValue = oldValue.Value;
        NewValue = newValue.Value;
        UpdaterId = updaterId;
    }

    public string NewValue { get; }

    public string OldValue { get; }

    public Guid UpdaterId { get; }
}