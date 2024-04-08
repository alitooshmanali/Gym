using Gym.Domain.Aggregates.Roles.Events;
using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.Aggregates.Roles;

public class Role : Entity, IAggregateRoot
{
    private Role() { }

    public RoleId Id { get; private set; }

    public Name Name { get; private set; }

    public Description Description { get; private set; }

    public RoleActivation IsActive { get; private set; }

    public static Role Create(RoleId id,
        Name name,
        Guid creatorId)
    {
        var isActive = RoleActivation.Create(true);
        var role = new Role()
        {
            Id = id,
            Name = name,
            IsActive = isActive
        };

        role.AddEvent(new RoleCreatedEvent(id, name, isActive, creatorId));

        return role;
    }

    public void ChangeName(Name name, Guid updaterId)
    {
        if (Name == name)
            return;

        AddEvent(new NameChangedEvent(Id, Name, name, updaterId));

        Name = name;
    }

    public void ChangeDescription(Description description, Guid updaterId)
    {
        if (Description == description)
            return;

        AddEvent(new DescriptionChangedEvent(Id, Description, description, updaterId));

        Description = description;
    }

    public void ChangeActivation(RoleActivation isActive, Guid updaterId)
    {
        if (IsActive == isActive)
            return;

        AddEvent(new ActivationChangedEvent(Id, IsActive, isActive, updaterId));

        IsActive = isActive;
    }

    public void Delete(Guid deleterId)
    {
        if (CanBeDeleted())
            throw new InvalidOperationException();

        AddEvent(new RoleDeletedEvent(Id, deleterId));

        MarkAsDeleted();
    }
}