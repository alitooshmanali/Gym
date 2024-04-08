using Gym.Domain.Aggregates.Roles.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

public class RoleActivationBuilder
{
    private bool _value;

    public RoleActivationBuilder()
    {
        _value = true;
    }

    public RoleActivationBuilder WithActive(bool value)
    {
        _value = value;

        return this;
    }

    public RoleActivation Build() => RoleActivation.Create(_value);
}