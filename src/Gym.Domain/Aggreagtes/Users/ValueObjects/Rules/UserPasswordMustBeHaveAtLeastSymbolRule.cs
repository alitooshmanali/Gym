using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Users.ValueObjects.Rules;

internal class UserPasswordMustBeHaveAtLeastSymbolRule: IBusinessRule
{
    private readonly string _value;

    public UserPasswordMustBeHaveAtLeastSymbolRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = DomainResources.User_Password_MustBeHaveAtLeastOneSymbol;

    public bool IsBroken()
    {
        return !_value.Any(char.IsSymbol);
    }
}