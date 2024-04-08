using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

internal class MobileMustBeStartWithPersianCodeRule: IBusinessRule
{
    private readonly string _value;

    public MobileMustBeStartWithPersianCodeRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = DomainResources.Gym_Mobile_MustBeStartWith09;

    public bool IsBroken()
    {
        return _value.StartsWith("09");
    }
}