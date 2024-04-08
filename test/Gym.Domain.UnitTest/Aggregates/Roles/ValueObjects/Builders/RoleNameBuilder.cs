using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

public class RoleNameBuilder
{
    private string _name;

    public RoleNameBuilder()
    {
        _name = "RoleName";
    }

    public RoleNameBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public Name Build() => Name.Create(_name);
}