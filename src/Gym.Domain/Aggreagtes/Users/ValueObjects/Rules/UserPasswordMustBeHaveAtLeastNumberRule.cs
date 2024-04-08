using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Users.ValueObjects.Rules;

internal class UserPasswordMustBeHaveAtLeastNumberRule : IBusinessRule
{
    private readonly string _value;

    public UserPasswordMustBeHaveAtLeastNumberRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = DomainResources.User_Password_MustBeHaveAtLeastOneNumber;

    public bool IsBroken()
    {
        return !_value.Any(char.IsDigit);
    }
}