using Gym.Domain.Aggregates.Users.ValueObjects.Rules;

namespace Gym.Domain.Aggregates.Users.ValueObjects;

public class Username : ValueObject
{
    private Username() { }

    public string Value { get; private init; }

    public static Username Create(string value)
    {
        CheckRule(new UsernameCannotBeEmptyRule(value));
        CheckRule(new UsernameCannotContainInvalidCharacterRule(value));


        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}