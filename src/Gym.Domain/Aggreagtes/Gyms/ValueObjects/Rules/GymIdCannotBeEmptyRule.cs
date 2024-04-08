using Gym.Domain.Properties;

namespace Gym.Domain.Aggregates.Gyms.ValueObjects.Rules;

internal class GymIdCannotBeEmptyRule: IBusinessRule
{
    private readonly Guid _value;

    public GymIdCannotBeEmptyRule(Guid value)
    {
        _value = value;
    }

    public string Message { get; } = string.Format(DomainResources.Global_ValueCannotBeEmpty, nameof(Gym.Id));

    public bool IsBroken()
    {
        return Guid.Empty.Equals(_value);
    }
}