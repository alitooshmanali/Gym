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

    public static User Create(UserId id,
        Username username,
        UserPassword password,
        UserActivation activation)
    {
        var user = new User
        {
            Id = id,
            Username = username,
            Password = password,
            IsActive = activation
        };

        user.AddEvent(new UserCreatedEvent(id, username));

        return user;
    }

    public void ChangeUsername(Username username)
    {
        if(Username == username)
            return;

        AddEvent(new UsernameChangedEvent(Id, Username, username));

        Username = username;
    }

    public void ChangePassword(UserPassword password)
    {
        if(Password == password)
            return;

        Password = password;
    }

    public void ChangeUserActivation(UserActivation isActive)
    {
        if(IsActive == isActive)
            return;

        AddEvent(new UserChangeActivationEvent(Id, IsActive, isActive));

        IsActive = isActive;
    }

    public void Delete()
    {
        if (CanBeDeleted())
            throw new InvalidOperationException();

        AddEvent(new UserDeletedEvent(Id));

        MarkAsDeleted();
    }
}