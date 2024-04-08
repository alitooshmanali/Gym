using FluentAssertions;
using Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects;

public class RoleActivationUnitTest
{
    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        var isActive = false;

        // act
        var roleActivation = new RoleActivationBuilder().WithActive(isActive).Build();

        // assert
        roleActivation.Value.Should().Be(isActive);
    }

    [Fact]
    public void TestEquality_WhenEverythingIsOk_MustBeTrue()
    {
        // arrange
        const bool value = false;

        // act
        var first = new RoleActivationBuilder().WithActive(value).Build();
        var second = new RoleActivationBuilder().WithActive(value).Build();

        // assert
        first.Should().Be(second);
    }
}