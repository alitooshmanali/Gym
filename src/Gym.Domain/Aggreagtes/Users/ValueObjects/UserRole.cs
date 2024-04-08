using Gym.Domain.Aggregates.Roles.ValueObjects;

namespace Gym.Domain.Aggregates.Users.ValueObjects;

public class UserRole : ValueObject
{
    private UserRole() { }

    public RoleId RoleId { get; private init; }

    public static UserRole Create(RoleId roleId)
    {
        return new() { RoleId = roleId };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return RoleId;
    }
}