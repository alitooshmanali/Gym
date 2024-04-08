using FluentAssertions;
using Gym.Domain.Aggregates.Roles;
using Gym.Domain.Exceptions;
using Gym.Domain.Properties;
using Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;

namespace Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects;

public class RoleIdUnitTest
{
    [Fact]
    public void TestCreate_ValueIsEmpty_ThrowException()
    {
        // arrange
        var roleId = Guid.Empty;

        // act
        var action = new Action(() => new RoleIdBuilder().WithValue(roleId).Build());

        // assert
        action.Should()
            .Throw<DomainException>()
            .WithMessage(string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(Role.Id)));
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        var roleId = Guid.NewGuid();

        // act
        var roleIdProperty = new RoleIdBuilder().WithValue(roleId).Build();

        // assert
        roleIdProperty.Value
            .Should().Be(roleId);
    }

    [Theory]
    [InlineData("37ABBF87-A96D-4593-A0C4-23FEC62D6559", true)]
    [InlineData("CD8BE2BC-982D-4258-9A2F-3AE3D967AA76", false)]
    public void TestEquality_WhenEverythingIsOk_ResultMustBeExpected(string value, bool result)
    {
        var first = new RoleIdBuilder().WithValue(Guid.Parse("37ABBF87-A96D-4593-A0C4-23FEC62D6559")).Build();
        var second = new RoleIdBuilder().WithValue(Guid.Parse(value)).Build();

        first.Equals(second).Should().Be(result);
    }
}