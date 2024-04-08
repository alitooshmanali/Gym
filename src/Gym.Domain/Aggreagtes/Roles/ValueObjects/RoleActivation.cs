namespace Gym.Domain.Aggregates.Roles.ValueObjects;

public class RoleActivation : ValueObject
{
    private RoleActivation() { }

    public bool Value { get; private init; }

    public static RoleActivation Create(bool value) => new() { Value = value };

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}