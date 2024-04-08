using Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

namespace Gym.Domain.Aggregates.Gyms.ValueObjects;

public class Mobile: ValueObject
{
    private Mobile()
    {
        
    }

    public string Value { get; private init; }

    public static Mobile Create(string value)
    {
        CheckRule(new MobileCannotBeEmptyRule(value));
        CheckRule(new MobileMustBeStartWithPersianCodeRule(value));
        CheckRule(new MobileMustBeElevenNumberRule(value));

        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}