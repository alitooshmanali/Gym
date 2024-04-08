using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Users.ValueObjects.Rules;

internal class UsernameCannotContainInvalidCharacterRule : IBusinessRule
{
    private static readonly char[] invalidCharacters = { '>', '<', '.', '/', '\\', '|', ':', '*', '?', '\'', '\"' };

    private readonly string _value;

    public UsernameCannotContainInvalidCharacterRule(string value)
    {
        _value = value;
    }

    public string Message { get; } =
        DomainResources.User_Username_CannotContainInvalidCharacters;

    public bool IsBroken()
    {
        return invalidCharacters.Any(_value.Contains);
    }
}