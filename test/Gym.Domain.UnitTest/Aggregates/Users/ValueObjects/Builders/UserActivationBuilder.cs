using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

public class UserActivationBuilder
{
    private bool _value;

    public UserActivationBuilder()
    {
        _value = true;
    }

    public UserActivationBuilder WithValue(bool value)
    {
        _value = value;

        return this;
    }

    public UserActivation Build() => UserActivation.Create(_value);
}