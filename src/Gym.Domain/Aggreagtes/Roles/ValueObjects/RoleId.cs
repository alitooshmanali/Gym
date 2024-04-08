using Gym.Domain.Aggregates.Roles.ValueObjects.Rules;

namespace Gym.Domain.Aggregates.Roles.ValueObjects;

public class RoleId : ValueObject
{
    private RoleId() { }

    public Guid Value { get; private init; }

    public static RoleId Create(Guid value)
    {
        CheckRule(new RoleIdCannotBeEmptyRule(value));

        return new() { Value = value };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}