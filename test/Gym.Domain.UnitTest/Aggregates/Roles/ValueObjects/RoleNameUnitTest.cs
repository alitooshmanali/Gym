using FluentAssertions;
using Gym.Domain.Aggregates.Roles;
using Gym.Domain.Exceptions;
using Gym.Domain.Properties;
using Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects;

public class RoleNameUnitTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void TestCreate_ValueIsEmpty_ThrowException(string value)
    {
        // act
        var action = new Action(() => new RoleNameBuilder().WithName(value).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(Role.Name)));
    }

    [Fact]
    public void TestCreate_ValueStartWithNumber_ThrowException()
    {
        // arrange
        const string value = "1Name";

        // act
        var action = new Action(() => new RoleNameBuilder().WithName(value).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(DomainResources.Name_CannotStartWithNumber);
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        const string value = "RoleName";

        // act
        var roleName = new RoleNameBuilder().WithName(value).Build();

        // assert
        roleName.Value.Should().Be(value);
    }

    [Fact]
    public void TestEquality_WhenEverythingIsOk_MustBeTrue()
    {
        // arrange
        const string value = "RoleName";

        // act
        var first = new RoleNameBuilder().WithName(value).Build();
        var second = new RoleNameBuilder().WithName(value).Build();

        // assert
        first.Should().Be(second);
    }
}