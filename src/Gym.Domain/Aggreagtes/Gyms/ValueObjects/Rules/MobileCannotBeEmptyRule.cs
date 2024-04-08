using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

internal class MobileCannotBeEmptyRule: IBusinessRule
{
    private readonly string _value;

    public MobileCannotBeEmptyRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(Gym.Mobile));

    public bool IsBroken()
    {
        return string.IsNullOrWhiteSpace(_value);
    }
}