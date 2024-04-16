using Gym.Domain.Aggreagtes.Users.ValueObjects;
using Gym.Domain.Aggregates.Users.Events;
using Gym.Domain.Aggregates.Users.ValueObjects;

namespace Gym.Domain.Aggreagtes.Users;

public class User : Entity, IAggregateRoot
{

    private User()
    {
    }

    public UserId Id { get; private set; }

    public Username Username { get; private set; }

    public UserPassword Password { get; private set; }

    public UserActivation IsActive { get; private set; }

    public UserAddress Address { get; private set; } = null!;

    public static User Create(UserId id,
        Username username,
        UserPassword password,
        UserActivation activation,
        Guid creatorId)
    {
        var user = new User
        {
            Id = id,
            Username = username,
            Password = password,
            IsActive = activation
        };

        user.AddEvent(new UserCreatedEvent(id, username, creatorId));

        return user;
    }

    public void ChangeUsername(Username username, Guid updaterId)
    {
        if(Username == username)
            return;

        AddEvent(new UsernameChangedEvent(Id, Username, username, updaterId));

        Username = username;
    }

    public void ChangePassword(UserPassword password)
    {
        if(Password == password)
            return;

        Password = password;
    }

    public void ChangeUserActivation(UserActivation isActive, Guid updaterId)
    {
        if(IsActive == isActive)
            return;

        AddEvent(new UserChangeActivationEvent(Id, IsActive, isActive, updaterId));

        IsActive = isActive;
    }

    public void ChangeUserAddress(UserAddress address, Guid updaterId)
    {
        if(Address == address)
            return;

        AddEvent(new UserAddressChangedEvent(Id, Address, address, updaterId));

        Address = address;
    }

    public void Delete(Guid deleterId)
    {
        if (CanBeDeleted())
            throw new InvalidOperationException();

        AddEvent(new UserDeletedEvent(Id, deleterId));

        MarkAsDeleted();
    }
}