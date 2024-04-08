using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users.Events;

public class UserRoleRemovedEvent: BaseDomainEvent
{
    public UserRoleRemovedEvent(UserId id, UserRole role, Guid removerId) 
        : base(id.Value)
    {
        RoleId = role.RoleId.Value;
        RemoverId = removerId;
    }

    public Guid RemoverId { get; }

    public Guid RoleId { get; }
}