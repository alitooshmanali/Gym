namespace Gym.Domain.UnitTest.Mocks.ValueObjects.Builders;

public class ValueObjectBuilder
{
    private Guid? _value1;
    private Guid? _value2;

    public ValueObjectBuilder()
    {
        _value1 = Guid.NewGuid();
        _value2 = Guid.NewGuid();
    }

    public ValueObjectBuilder WithId(Guid? value)
    {
        _value1 = value;
        return this;
    }

    public ValueObjectBuilder WithIds(Guid? value1, Guid? value2)
    {
        _value1 = value1;
        _value2 = value2;

        return this;
    }

    public ValueObject BuildSingleParam()
    {
        return new SingleValueObjectMock(_value1);
    }

    public ValueObject BuildMultiParam()
    {
        return new MultiValueObjectMock(_value1, _value2);
    }

    public ValueObject? BuildNull()
    {
        return null;
    }
}

internal class SingleValueObjectMock : ValueObject
{
    public SingleValueObjectMock(Guid? value)
    {
        Value = value;
    }

    private Guid? Value { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}

internal class MultiValueObjectMock : ValueObject
{
    public MultiValueObjectMock(Guid? value1, Guid? value2)
    {
        Value1 = value1;
        Value2 = value2;
    }

    private Guid? Value1 { get; set; }

    private Guid? Value2 { get; set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value1;
        yield return Value2;
    }
}