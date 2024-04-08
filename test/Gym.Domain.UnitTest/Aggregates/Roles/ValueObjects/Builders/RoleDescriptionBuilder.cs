using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

public class RoleDescriptionBuilder
{
    private string _value;

    public RoleDescriptionBuilder()
    {
        _value = "RoleDescription";
    }

    public RoleDescriptionBuilder WithDescription(string value)
    {
        _value = value;

        return this;
    }

    public Description Build() => Description.Create(_value);
}