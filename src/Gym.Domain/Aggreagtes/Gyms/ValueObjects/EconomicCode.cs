using Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

namespace Gym.Domain.Aggregates.Gyms.ValueObjects;

public class EconomicCode: ValueObject
{
    private EconomicCode() { }

    public string Value { get; private init; }

    public static EconomicCode Create(string value)
    {
        CheckRule(new EconomicCodeMustBeTwelveNumberRule(value));

        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}