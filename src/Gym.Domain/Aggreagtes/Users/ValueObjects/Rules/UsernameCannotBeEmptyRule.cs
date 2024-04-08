using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Users.ValueObjects.Rules;

internal class UsernameCannotBeEmptyRule: IBusinessRule
{
    private readonly string _value;

    public UsernameCannotBeEmptyRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(User.Username));

    public bool IsBroken()
    {
        return string.IsNullOrWhiteSpace(_value);
    }
}