using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserRoleAddedEvent : BaseDomainEvent
{
    public UserRoleAddedEvent(UserId id, UserRole role, Guid creatorId)
        : base(id.Value)
    {
        RoleId = role.RoleId.Value;
        CreatorId = creatorId;
    }

    public Guid CreatorId { get; }

    public Guid RoleId { get; }
}