namespace Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

internal class EconomicCodeMustBeTwelveNumberRule: IBusinessRule
{
    private readonly string _value;

    public EconomicCodeMustBeTwelveNumberRule(string value)
    {
        _value = value;
    }

    public string Message { get; }

    public bool IsBroken()
    {
        return _value.Length == 12;
    }
}