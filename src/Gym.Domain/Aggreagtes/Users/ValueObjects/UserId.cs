using Gym.Domain.Aggregates.Users.ValueObjects.Rules;

namespace Gym.Domain.Aggregates.Users.ValueObjects;

public class UserId : ValueObject
{
    private UserId() { }

    public Guid Value { get; private init; }

    public static UserId Create(Guid value)
    {
        CheckRule(new UserIdCannotBeEmptyRule(value));

        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}