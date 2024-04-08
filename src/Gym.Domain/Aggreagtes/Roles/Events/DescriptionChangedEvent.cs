using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.Aggregates.Roles.Events;

public class DescriptionChangedEvent : BaseDomainEvent
{
    public DescriptionChangedEvent(RoleId id, Description oldValue, Description newValue, Guid updaterId)
        : base(id.Value)
    {
        OldValue = oldValue?.Value;
        NewValue = newValue?.Value;
        UpdaterId = updaterId;
    }

    public Guid UpdaterId { get; }

    public string? NewValue { get; }

    public string? OldValue { get; }
}