using FluentAssertions;
using Gym.Domain.Aggregates.Users.Events;
using Gym.Domain.UnitTest.Aggregates.Users.Builders;
using Gym.Domain.UnitTest.Aggregates.Users.ValueObjects.Builders;
using Gym.Domain.UnitTest.Helpers;

namespace Gym.Domain.UnitTest.Aggregates.Users;

public partial class UserUnitTest
{
    [Fact]
    public void TestChangeUsername_ValueIsSame_MustBeNotHappened()
    {
        // arrange
        var updaterId = Guid.NewGuid();
        var username = new UsernameBuilder().Build();
        var user = new UserBuilder()
            .WithUsername(username.Value).Build();

        user.ClearEvents();

        // act
        user.ChangeUsername(username, updaterId);
        
        // assert
        user.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeUsername_EverythingIsOk_MustBeChanged()
    {
        // arrange
        var userId = Guid.NewGuid();
        var updaterId = Guid.NewGuid();
        var username = "ChangeUsername";
        var updateUsername = new UsernameBuilder().WithUsername(username).Build();
        var user = new UserBuilder()
            .WithId(userId)
            .Build();
        var oldUsername = user.Username;

        user.ClearEvents();

        // act
        user.ChangeUsername(updateUsername, updaterId);

        var changedEvent = user.AssertPublishedDomainEvent<UsernameChangedEvent>();

        // assert
        user.DomainEvents.Should().HaveCount(1);
        changedEvent.AggregateId.Should().Be(userId);
        changedEvent.OldValue.Should().Be(oldUsername.Value);
        changedEvent.NewValue.Should().Be(updateUsername.Value);
        changedEvent.UpdaterId.Should().Be(updaterId);
        user.Id.Value.Should().Be(userId);
        user.Username.Value.Should().Be(updateUsername.Value);
    }

    [Fact]
    public void TestChangePassword_ValueIsSame_MustBeNotHappened()
    {
        // arrange
        var password = new UserPasswordBuilder().Build();
        var user = new UserBuilder()
            .WithPassword(password.Value)
            .Build();

        user.ClearEvents();

        // act
        user.ChangePassword(password);

        // assert
        user.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangePassword_EverythingIsOk_MustBeChanged()
    {
        // arrange
        var userId = Guid.NewGuid();
        var password = new UserPasswordBuilder().Build();
        var user = new UserBuilder()
            .WithId(userId)
            .Build();

        user.ClearEvents();

        // act
        user.ChangePassword(password);

        // assert
        user.DomainEvents.Should().HaveCount(0);
        user.Id.Value.Should().Be(userId);
        user.Password.Value.Should().Be(password.Value);
    }

    [Fact]
    public void TestChangeUserActivation_ValueIsSame_MustBeNotHappened()
    {
        // arrange
        var isActive = new UserActivationBuilder().Build();
        var updaterId = Guid.NewGuid();
        var user = new UserBuilder()
            .WithIsActive(isActive.Value)
            .Build();

        user.ClearEvents();

        // act
        user.ChangeUserActivation(isActive, updaterId);

        // assert
        user.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeUserActivation_EverythingIsOk_MustBeChanged()
    {
        // arrange
        var userId = Guid.NewGuid();
        var isActive = false;
        var updaterId = Guid.NewGuid();
        var user = new UserBuilder()
            .WithId(userId)
            .Build();

        user.ClearEvents();

        // act
        user.ChangeUserActivation(new UserActivationBuilder().WithValue(isActive).Build(), updaterId);

        var changeEvent = user.AssertPublishedDomainEvent<UserChangeActivationEvent>();

        // assert
        user.DomainEvents.Should().HaveCount(1);
        changeEvent.AggregateId.Should().Be(userId);
        changeEvent.OldValue.Should().BeTrue();
        changeEvent.NewValue.Should().BeFalse();
        changeEvent.UpdaterId.Should().Be(updaterId);

        user.Id.Value.Should().Be(userId);
        user.IsActive.Value.Should().Be(isActive);
    }

    [Fact]
    public void TestChangeUserAddress_ValueIsSame_MustBeNotHappened()
    {
        // arrange
        var user = new UserBuilder()
            .Build();

        user.ClearEvents();

        // act
        user.ChangeUserAddress(null!, Guid.NewGuid());

        // assert
        user.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeUserAddress_EverythingIsOk_MustBeChanged()
    {
        // arrange
        var userId = Guid.NewGuid();
        const string countryName = "Iran";
        const string cityName = "Tehran";
        const string regionName = "Tehran";
        const string address = null!;
        var updaterId = Guid.NewGuid();
        var user = new UserBuilder()
            .WithId(userId)
            .Build();
        var userAddress = new UserAddressBuilder()
            .WithCountry(countryName)
            .WithCityName(cityName)
            .WithRegionName(regionName)
            .WithAddress(address)
            .Build();

        user.ClearEvents();

        // act
        user.ChangeUserAddress(userAddress, updaterId);

        var changeEvent = user.AssertPublishedDomainEvent<UserAddressChangedEvent>();

        // assert
        user.DomainEvents.Should().HaveCount(1);
        changeEvent.AggregateId.Should().Be(userId);
        changeEvent.OldCountryName.Should().BeNull();
        changeEvent.OldCityName.Should().BeNull();
        changeEvent.OldRegionName.Should().BeNull();
        changeEvent.OldAddress.Should().BeNull();

        changeEvent.NewCountryName.Should().Be(countryName);
        changeEvent.NewCityName.Should().Be(cityName);
        changeEvent.NewRegionName.Should().Be(regionName);
        changeEvent.NewAddress.Should().Be(address);

        changeEvent.UpdaterId.Should().Be(updaterId);

        user.Id.Value.Should().Be(userId);
        user.Address.Should().Be(userAddress);
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange

        var userId = Guid.NewGuid();
        var username = "UserUsername";
        var password = "UserPas$w0rd";
        var creatorId = Guid.NewGuid();

        // act
        var user = new UserBuilder()
            .WithId(userId)
            .WithUsername(username)
            .WithPassword(password)
            .WithCreatorId(creatorId)
            .Build();

        var createEvent = user.AssertPublishedDomainEvent<UserCreatedEvent>();

        createEvent.AggregateId.Should().Be(userId);
        createEvent.Username.Should().Be(username);
        createEvent.CreatorId.Should().Be(creatorId);

        user.Id.Value.Should().Be(userId);
        user.Username.Value.Should().Be(username);
        user.Password.Value.Should().Be(password);
    }

    [Fact]
    public void TestDelete_WhenEverythingIsOk_MustBeMarkedAsDeleted()
    {
        // arrange
        var deleterId = Guid.NewGuid();
        var user = new UserBuilder().Build();

        user.ClearEvents();

        // act
        user.Delete(deleterId);

        // assert
        var deletedEvent = user.AssertPublishedDomainEvent<UserDeletedEvent>();
        deletedEvent.AggregateId.Should().Be(user.Id.Value);
        deletedEvent.DeleterId.Should().Be(deleterId);
        user.CanBeDeleted().Should().BeTrue();
        user.DomainEvents.Should().HaveCount(1);
    }

    [Fact]
    public void TestDelete_WhenAlreadyDeleted_ThrowsException()
    {
        // arrange
        var user = new UserBuilder().Build();
        var deleterId = Guid.NewGuid();
        user.Delete(deleterId);

        // act
        var action = new Action(() => user.Delete(deleterId));

        // assert
        action.Should().Throw<InvalidOperationException>();
    }
}