using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Users.ValueObjects.Rules;

internal class UserPasswordMustBeHaveAtLeastBoldCharacterRule: IBusinessRule
{
    private readonly string _value;

    public UserPasswordMustBeHaveAtLeastBoldCharacterRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = DomainResources.User_Password_MustBeHaveAtLeastOneBoldCharacter;

    public bool IsBroken()
    {
        return !_value.Any(char.IsUpper);
    }
}