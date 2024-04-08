using FluentAssertions;
using Gym.Domain.Aggregates.Users;
using Gym.Domain.Exceptions;
using Gym.Domain.Properties;
using Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Users.ValueObjects;

public class UserIdUnitTest
{
    [Fact]
    public void TestCreate_ValueIsEmpty_ThrowException()
    {
        // arrange
        var userId = Guid.Empty;

        // act
        var action = new Action(() => new UserIdBuilder().WithValue(userId).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(User.Id)));
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        var userId = Guid.NewGuid();

        // act
        var userIdProperty = new UserIdBuilder().WithValue(userId).Build();

        // assert
        userIdProperty.Value
            .Should().Be(userId);
    }

    [Theory]
    [InlineData("37ABBF87-A96D-4593-A0C4-23FEC62D6559", true)]
    [InlineData("CD8BE2BC-982D-4258-9A2F-3AE3D967AA76", false)]
    public void TestEquality_WhenEverythingIsOk_ResultMustBeExpected(string value, bool result)
    {
        var first = new UserIdBuilder().WithValue(Guid.Parse("37ABBF87-A96D-4593-A0C4-23FEC62D6559")).Build();
        var second = new UserIdBuilder().WithValue(Guid.Parse(value)).Build();

        first.Equals(second).Should().Be(result);
    }
}