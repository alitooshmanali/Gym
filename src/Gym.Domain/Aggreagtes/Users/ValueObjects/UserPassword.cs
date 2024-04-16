using Gym.Domain.Aggreagtes.Users.ValueObjects.Rules;
using Gym.Domain.Aggregates.Users.ValueObjects.Rules;

namespace Gym.Domain.Aggreagtes.Users.ValueObjects;

public class UserPassword : ValueObject
{
    private UserPassword() { }

    public string Value { get; private init; }

    public static UserPassword Create(string value)
    {
       CheckRule(new UserPasswordCannotBeEmptyRule(value));
       CheckRule(new UserPasswordMustBeHaveAtLeastNumberRule(value));
       CheckRule(new UserPasswordMustBeHaveAtLeastSymbolRule(value));
       CheckRule(new UserPasswordMustBeHaveAtLeastBoldCharacterRule(value));

        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}