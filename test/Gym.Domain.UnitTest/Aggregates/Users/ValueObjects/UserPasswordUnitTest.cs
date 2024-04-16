using FluentAssertions;
using Gym.Domain.Exceptions;
using Gym.Domain.Properties;
using Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;
using User = Gym.Domain.Aggreagtes.Users.User;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects;

public class UserPasswordUnitTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void TestCreate_ValueIsEmpty_ThrowException(string value)
    {
        // act
        var action = new Action(() => new UserPasswordBuilder().WithPassword(value).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(User.Password)));
    }

    [Fact]
    public void TestCreate_ValueWithOutHaveAtLeastOneNumber_ThrowException()
    {
        // arrange
        var value = "Password";

        // act
        var action = new Action(() => new UserPasswordBuilder().WithPassword(value).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(DomainResources.User_Password_MustBeHaveAtLeastOneNumber);
    }

    [Fact]
    public void TestCreate_ValueWithOutHaveAtLeastOneSymbol_ThrowException()
    {
        // arrange
        var value = "Passw0rd";

        // act
        var action = new Action(() => new UserPasswordBuilder().WithPassword(value).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(DomainResources.User_Password_MustBeHaveAtLeastOneSymbol);
    }

    [Fact]
    public void TestCreate_ValueWithOutHaveAtLeastOneBoldCharacter_ThrowException()
    {
        // arrange
        var value = "pa$$w0rd";

        // act
        var action = new Action(() => new UserPasswordBuilder().WithPassword(value).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(DomainResources.User_Password_MustBeHaveAtLeastOneBoldCharacter);
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        const string value = "Pa$$w0rd";

        // act
        var userPassword = new UserPasswordBuilder().WithPassword(value).Build();

        // assert
        userPassword.Value.Should().Be(value);
    }

    [Fact]
    public void TestEquality_WhenEverythingIsOk_MustBeTrue()
    {
        const string value = "Pa$$w0rd";
        var first = new UsernameBuilder().WithUsername(value).Build();
        var second = new UsernameBuilder().WithUsername(value).Build();

        first.Should().Be(second);
    }
}