using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.Users.Events;
using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggregates.Users;

public partial class User
{
    public void AddRole(RoleId roleId, Guid creatorId)
    {
        if (roles.Any(i => i.RoleId == roleId))
            return;

        var userRole = UserRole.Create(roleId);

        AddEvent(new UserRoleAddedEvent(Id, userRole, creatorId));

        roles.Add(userRole);
    }

    public void RemoveRole(RoleId roleId, Guid removerId)
    {
        var userRole = roles.Find(i => i.RoleId == roleId);

        if(userRole is null)
            return;

        AddEvent(new UserRoleRemovedEvent(Id, userRole, removerId));

        roles.Remove(userRole);
    }
}