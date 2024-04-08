using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.ValueObjects.Rules;

internal class NameCannotBeEmptyRule: IBusinessRule
{
    private readonly string _value;

    public NameCannotBeEmptyRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(Name));

    public bool IsBroken()
    {
        return string.IsNullOrWhiteSpace(_value);
    }
}