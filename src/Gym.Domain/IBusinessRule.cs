namespace Gym.Domain;

public interface IBusinessRule
{
    public string Message { get; }

    public bool IsBroken();
}