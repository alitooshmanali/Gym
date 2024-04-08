using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Users.ValueObjects.Rules;

internal class UserIdCannotBeEmptyRule: IBusinessRule
{
    private readonly Guid _value;

    public UserIdCannotBeEmptyRule(Guid value)
    {
        _value = value;
    }

    public string Message { get; } = string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(User.Id));

    public bool IsBroken()
    {
        return Guid.Empty.Equals(_value);
    }
}