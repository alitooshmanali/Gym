using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.ValueObjects.Rules;

internal class NameCannotContainInvalidCharactersRule: IBusinessRule
{
    private static readonly char[] invalidCharacters = { '>', '<', '.', '/', '\\', '|', ':', '*', '?', '\'', '\"' };

    private readonly string _value;

    public NameCannotContainInvalidCharactersRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = DomainResources.Name_CannotContainInvalidCharacters;

    public bool IsBroken()
    {
        return invalidCharacters.Any(_value.Contains);
    }
}