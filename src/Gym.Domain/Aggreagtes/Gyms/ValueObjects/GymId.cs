using Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

namespace Gym.Domain.Aggregates.Gyms.ValueObjects;

public class GymId: ValueObject
{
    private GymId() { }

    public Guid Value { get; private init; }

    public static GymId Create(Guid value)
    {
        CheckRule(new GymIdCannotBeEmptyRule(value));

        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}