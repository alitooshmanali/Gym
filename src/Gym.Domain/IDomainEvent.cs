namespace Gym.Domain;

public interface IDomainEvent
{
    Guid AggregateId { get; }

    DateTimeOffset EventTime { get; }

    Dictionary<string, object> Flatten();
}