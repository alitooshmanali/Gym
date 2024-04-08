using FluentAssertions;
using Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects;

public class UserActivationUnitTest
{
    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        var value = false;

        // act 
        var active = new UserActivationBuilder().WithValue(value).Build();

        // assert
        active.Value
            .Should()
            .BeFalse();
    }

    [Fact]
    public void TestEquality_WhenEverythingIsOk_MustBeTrue()
    {
        const bool value = true;
        var first = new UserActivationBuilder().WithValue(value).Build();
        var second = new UserActivationBuilder().WithValue(value).Build();

        first.Should().Be(second);
    }
}