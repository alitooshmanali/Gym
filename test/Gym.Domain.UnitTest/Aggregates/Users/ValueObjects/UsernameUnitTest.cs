using FluentAssertions;
using Gym.Domain.Aggregates.Users.ValueObjects;
using Gym.Domain.Aggregates.Users;
using Gym.Domain.Exceptions;
using Gym.Domain.Properties;
using System.Xml.Linq;
using Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects;

public class UsernameUnitTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void TestCreate_ValueIsEmpty_ThrowException(string value)
    {
        // act
        var action = new Action(() => new UsernameBuilder().WithUsername(value).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(User.Username)));
    }

    [Theory]
    [InlineData("Na>me")]
    [InlineData("Na<me")]
    [InlineData("Na.me")]
    [InlineData("Na/me")]
    [InlineData("Na\\me")]
    [InlineData("Na|me")]
    [InlineData("Na:me")]
    [InlineData("Na*me")]
    [InlineData("Na?me")]
    [InlineData("Na'me")]
    [InlineData("Na\"me")]
    public void TestCreate_WhenValueContainsInvalidCharacters_ThrowsException(string value)
    {
        var action = new Action(() => new UsernameBuilder().WithUsername(value).Build());

        action.Should()
            .Throw<DomainException>()
            .WithMessage(string.Format(DomainResources.User_Username_CannotContainInvalidCharacters, nameof(User.Username)));
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        const string value = "Username";

        // act
        var username = new UsernameBuilder().WithUsername(value).Build();

        // assert
        username.Value.Should().Be(value);
    }

    [Fact]
    public void TestEquality_WhenEverythingIsOk_MustBeTrue()
    {
        const string value = "Username";
        var first = new UsernameBuilder().WithUsername(value).Build();
        var second = new UsernameBuilder().WithUsername(value).Build();

        first.Should().Be(second);
    }
}