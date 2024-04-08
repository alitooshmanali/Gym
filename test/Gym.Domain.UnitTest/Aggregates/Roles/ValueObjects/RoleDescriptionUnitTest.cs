using FluentAssertions;
using Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects;

public class RoleDescriptionUnitTest
{
    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        const string value = "RoleDescription";

        // act
        var roleDescription = new RoleDescriptionBuilder().WithDescription(value).Build();

        // assert
        roleDescription.Value.Should().Be(value);
    }

    [Fact]
    public void TestEquality_WhenEverythingIsOk_MustBeTrue()
    {
        // arrange
        const string value = "RoleDescription";

        // act
        var first = new RoleDescriptionBuilder().WithDescription(value).Build();
        var second = new RoleDescriptionBuilder().WithDescription(value).Build();

        // assert
        first.Should().Be(second);
    }
}