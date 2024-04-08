using FluentAssertions;
using Gym.Domain.UnitTest.Mocks.ValueObjects.Builders;

namespace Gym.Domain.UnitTest;

public class ValueObjectUnitTest
{
    [Fact]
    public void TestEqualOperator_WhenBothSideAreNull_MustBeTrue()
    {
        ValueObject firstValueObject = null;
        ValueObject secondValueObject = null;

        (firstValueObject == secondValueObject).Should().BeTrue();
    }

    [Fact]
    public void TestEqualOperator_WhenOneSideIsNull_MustBeFalse()
    {
        var firstValueObject = new ValueObjectBuilder()
            .BuildSingleParam();

        (null == firstValueObject).Should().BeFalse();
    }

    [Fact]
    public void TestEqualOperator_WhenValuesAreEqual_MustBeTrue()
    {
        var id = Guid.NewGuid();
        var firstValueObject = new ValueObjectBuilder()
            .WithId(id)
            .BuildSingleParam();
        var secondValueObject = new ValueObjectBuilder()
            .WithId(id)
            .BuildSingleParam();

        (firstValueObject == secondValueObject).Should().BeTrue();
    }

    [Fact]
    public void TestEqualOperator_WhenValuesAreNullEqual_MustBeFalse()
    {
        var firstValueObject = new ValueObjectBuilder()
            .BuildSingleParam();
        var secondValueObject = new ValueObjectBuilder()
            .BuildSingleParam();

        (firstValueObject == secondValueObject).Should().BeFalse();
    }

    [Fact]
    public void TestEquals_WhenDifferentType_MustBeFalse()
    {
        new ValueObjectBuilder().BuildSingleParam().Equals(new()).Should().BeFalse();
    }

    [Fact]
    public void TestEquals_WhenEqual_MustBeTrue()
    {
        var value = Guid.NewGuid();
        var firstValueObject = new ValueObjectBuilder().WithIds(value, value).BuildMultiParam();
        var secondValueObject = new ValueObjectBuilder().WithIds(value, value).BuildMultiParam();

        firstValueObject.Equals(secondValueObject).Should().BeTrue();
    }

    [Fact]
    public void TestEquals_WhenNull_MustBeFalse()
    {
        var valueObject = new ValueObjectBuilder().BuildSingleParam();

        valueObject.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void TestGetHashCode_WhenNotNull_MustBeCorrect()
    {
        var firstValue = Guid.NewGuid();
        var secondValue = Guid.NewGuid();

        new ValueObjectBuilder().WithIds(firstValue, secondValue)
            .BuildMultiParam()
            .GetHashCode()
            .Should().Be(firstValue.GetHashCode() ^ secondValue.GetHashCode());
    }

    [Fact]
    public void TestGetHashCode_WhenNull_MustBeZero()
    {
        new ValueObjectBuilder().WithIds(null, null).BuildMultiParam().GetHashCode().Should().Be(0);
    }

    [Fact]
    public void TestNotEqualOperator_WhenBothSideAreNull_MustBeFalse()
    {
        var firstValueObject = new ValueObjectBuilder().BuildNull();
        var secondValueObject = new ValueObjectBuilder().BuildNull();

        (firstValueObject != secondValueObject).Should().BeFalse();
    }

    [Fact]
    public void TestNotEqualOperator_WhenOneSideIsNull_MustBeTrue()
    {
        var valueObject = new ValueObjectBuilder().BuildSingleParam();

        (valueObject != null).Should().BeTrue();
        (null != valueObject).Should().BeTrue();
    }

    [Fact]
    public void TestNotEqualOperator_WhenValuesAreEqual_MustBeFalse()
    {
        var value = Guid.NewGuid();
        var firstValueObject = new ValueObjectBuilder().WithIds(value, value).BuildMultiParam();
        var secondValueObject = new ValueObjectBuilder().WithIds(value, value).BuildMultiParam();

        (firstValueObject != secondValueObject).Should().BeFalse();
    }

    [Fact]
    public void TestNotEqualOperator_WhenValuesAreNotEqual_MustBeTrue()
    {
        var firstValueObject = new ValueObjectBuilder().BuildSingleParam();
        var secondValueObject = new ValueObjectBuilder().BuildSingleParam();

        (firstValueObject != secondValueObject).Should().BeTrue();
    }
}