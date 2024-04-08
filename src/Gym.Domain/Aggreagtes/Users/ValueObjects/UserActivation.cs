namespace Gym.Domain.Aggregates.Users.ValueObjects;

public class UserActivation : ValueObject
{
    private UserActivation() { }

    public bool Value { get; private init; }

    public static UserActivation Create(bool value)
    {
        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}