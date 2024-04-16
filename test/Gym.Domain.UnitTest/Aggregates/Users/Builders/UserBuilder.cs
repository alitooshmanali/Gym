using Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;
using User = Gym.Domain.Aggreagtes.Users.User;

namespace Gym.Domain.UnitTest.Aggregates.Users.Builders;

public class UserBuilder
{
    private Guid _id;

    private string _username;

    private string _password;

    private bool _isActive;

    private Guid _creatorId;

    public UserBuilder()
    {
        _id = Guid.NewGuid();
        _creatorId = Guid.NewGuid();
        _username = "Username";
        _password = "UserPa$$w0rd";
        _isActive = true;
    }

    public UserBuilder WithId(Guid value)
    {
        _id = value;

        return this;
    }

    public UserBuilder WithUsername(string value)
    {
        _username = value;

        return this;
    }

    public UserBuilder WithPassword(string value)
    {
        _password = value;

        return this;
    }

    public UserBuilder WithCreatorId(Guid value)
    {
        _creatorId = value;

        return this;
    }

    public UserBuilder WithIsActive(bool value)
    {
        _isActive = value;

        return this;
    }

    public User Build() => User.Create(
        new UserIdBuilder().WithValue(_id).Build(),
        new UsernameBuilder().WithUsername(_username).Build(),
        new UserPasswordBuilder().WithPassword(_password).Build(),
        new UserActivationBuilder().WithValue(_isActive).Build(),
        _creatorId);
}