using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

public class UserIdBuilder
{
    private Guid _value;

    public UserIdBuilder()
    {
        _value = Guid.NewGuid();
    }

    public UserIdBuilder WithValue(Guid value)
    {
        _value = value;

        return this;
    }

    public UserId Build() => UserId.Create(_value);
}