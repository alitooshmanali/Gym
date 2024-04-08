using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

public class UsernameBuilder
{
    private string _value;

    public UsernameBuilder()
    {
        _value = "Username";
    }

    public UsernameBuilder WithUsername(string value)
    {
        _value = value;

        return this;
    }

    public Username Build() => Username.Create(_value);
}