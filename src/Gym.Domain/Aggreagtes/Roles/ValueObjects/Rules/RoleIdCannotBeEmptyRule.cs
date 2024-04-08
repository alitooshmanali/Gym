using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Roles.ValueObjects.Rules;

internal class RoleIdCannotBeEmptyRule : IBusinessRule
{
    private readonly Guid _value;

    public RoleIdCannotBeEmptyRule(Guid value)
    {
        _value = value;
    }

    public string Message { get; } = string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(Role.Id));

    public bool IsBroken()
    {
        return Guid.Empty.Equals(_value);
    }
}