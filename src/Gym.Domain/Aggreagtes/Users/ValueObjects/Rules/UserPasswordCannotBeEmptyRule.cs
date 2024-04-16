using Gym.Domain.Properties;

namespace Gym.Domain.Aggreagtes.Users.ValueObjects.Rules;

internal class UserPasswordCannotBeEmptyRule : IBusinessRule
{
    private readonly string _value;

    public UserPasswordCannotBeEmptyRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(Aggreagtes.Users.User.Password));

    public bool IsBroken()
    {
        return string.IsNullOrWhiteSpace(_value);
    }
}