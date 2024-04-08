using Gym.Domain.Aggregates.Gyms.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.Aggregates.Gyms.Events;

public class GymCreatedEvent: BaseDomainEvent
{
    public GymCreatedEvent(GymId id, Name name, EconomicCode economicCode, Guid creatorId) 
        : base(id.Value)
    {
        Name = name.Value;
        EconomicCode = economicCode.Value;
        CreatorId = creatorId;
    }

    public Guid CreatorId { get; }

    public string Name { get; }

    public string EconomicCode { get; }
}