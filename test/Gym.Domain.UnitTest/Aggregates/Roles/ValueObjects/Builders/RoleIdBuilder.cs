using Gym.Domain.Aggregates.Roles.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

public class RoleIdBuilder
{
    private Guid _value;

    public RoleIdBuilder()
    {
        _value = Guid.NewGuid();
    }

    public RoleIdBuilder WithValue(Guid value)
    {
        _value = value;

        return this;
    }

    public RoleId Build() => RoleId.Create(_value);
}