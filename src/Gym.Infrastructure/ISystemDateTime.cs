namespace Gym.Infrastructure;

public interface ISystemDateTime
{
    DateTimeOffset UtcNow { get; }
}