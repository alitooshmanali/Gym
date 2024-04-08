using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

internal class MobileMustBeElevenNumberRule: IBusinessRule
{
    private readonly string _value;

    public MobileMustBeElevenNumberRule(string value)
    {
        _value = value;
    }

    public string Message { get; } = DomainResources.Gym_Mobile_MustBeValid;

    public bool IsBroken()
    {
        return _value.Length == 11;
    }
}