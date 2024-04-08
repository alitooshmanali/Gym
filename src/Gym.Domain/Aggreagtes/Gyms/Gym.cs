using Gym.Domain.Aggregates.Gyms.Events;
using Gym.Domain.Aggregates.Gyms.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.Aggregates.Gyms;

public class Gym : Entity, IAggregateRoot
{
    private Gym() { }

    public GymId Id { get; private set; }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public EconomicCode EconomicCode { get; private set; }

    public Mobile Mobile { get; private set; }

    public static Gym Create(GymId id,
        Name name,
        EconomicCode economicCode,
        Guid creatorId)
    {
        var gym = new Gym
        {
            Id = id,
            Name = name,
            EconomicCode = economicCode
        };

        gym.AddEvent(new GymCreatedEvent(id, name, economicCode, creatorId));

        return gym;
    }

    public void ChangeName(Name value, Guid updaterId)
    {
        if (Name == value)
            return;

        AddEvent(new GymNameChangedEvent(Id, Name, value, updaterId));
    }

    public void ChangeDescription(Description value, Guid updaterId)
    {
        if (Description == value)
            return;
        AddEvent(new GymDescriptionChangedEvent(Id, Description, value, updaterId));
    }

    public void ChangeEconomicCode(EconomicCode value, Guid updaterId)
    {
        if(EconomicCode == value)
            return;

        AddEvent(new EconomicCodeChangedEvent(Id, EconomicCode, value, updaterId));

        EconomicCode = value;
    }

    public void ChangeMobile(Mobile value, Guid updaterId)
    {
        if(Mobile == value)
            return;

        AddEvent(new MobileChangedEvent(Id, Mobile, value, updaterId));

        Mobile = value;
    }

    public void Delete(Guid deleterId)
    {
        if (CanBeDeleted())
            throw new InvalidOperationException();

        MarkAsDeleted();
    }
}