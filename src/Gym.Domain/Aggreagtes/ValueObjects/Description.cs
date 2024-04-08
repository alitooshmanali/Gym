namespace Gym.Domain.Aggregates.ValueObjects;

public class Description: ValueObject
{
    private Description()
    {
    }

    public string Value { get; private init; }

    public static Description Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null!;

        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}