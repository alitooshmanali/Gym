using Gym.Domain.Aggreagtes.Users.ValueObjects;
using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

public class UserPasswordBuilder
{
    private string _value;

    public UserPasswordBuilder()
    {
        _value = "Pa$$w0rd";
    }

    public UserPasswordBuilder WithPassword(string value)
    {
        _value = value;

        return this;
    }

    public UserPassword Build() => UserPassword.Create(_value);
}