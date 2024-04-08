using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.ValueObjects.Rules;

internal class NameCannotStartWithNumberRule: IBusinessRule
{
    private readonly string _value;

    public NameCannotStartWithNumberRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = DomainResources.Name_CannotStartWithNumber;

    public bool IsBroken()
    {
        return char.IsDigit(_value[0]);
    }
}