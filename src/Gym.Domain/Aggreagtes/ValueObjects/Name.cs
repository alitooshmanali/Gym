using Gym.Domain.Aggregates.ValueObjects.Rules;

namespace Gym.Domain.Aggregates.ValueObjects;

public class Name : ValueObject
{
    private Name() { }

    public string Value { get; private init; }

    public static Name Create(string value)
    {
        CheckRule(new NameCannotBeEmptyRule(value));
        CheckRule(new NameCannotStartWithNumberRule(value));
        CheckRule(new NameCannotContainInvalidCharactersRule(value));


        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}