﻿using FluentAssertions;
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
        var username = new UsernameBuilder().Build();
        var user = new UserBuilder()
            .WithUsername(username.Value).Build();

        user.ClearEvents();

        // act
        user.ChangeUsername(username);

        // assert
        user.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeUsername_EverythingIsOk_MustBeChanged()
    {
        // arrange
        var userId = Guid.NewGuid();
        var username = "ChangeUsername";
        var updateUsername = new UsernameBuilder().WithUsername(username).Build();
        var user = new UserBuilder()
            .WithId(userId)
            .Build();
        var oldUsername = user.Username;

        user.ClearEvents();

        // act
        user.ChangeUsername(updateUsername);

        var changedEvent = user.AssertPublishedDomainEvent<UsernameChangedEvent>();

        // assert
        user.DomainEvents.Should().HaveCount(1);
        changedEvent.AggregateId.Should().Be(userId);
        changedEvent.OldValue.Should().Be(oldUsername.Value);
        changedEvent.NewValue.Should().Be(updateUsername.Value);
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
        var user = new UserBuilder()
            .WithIsActive(isActive.Value)
            .Build();

        user.ClearEvents();

        // act
        user.ChangeUserActivation(isActive);

        // assert
        user.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeUserActivation_EverythingIsOk_MustBeChanged()
    {
        // arrange
        var userId = Guid.NewGuid();
        var isActive = false;
        var user = new UserBuilder()
            .WithId(userId)
            .Build();

        user.ClearEvents();

        // act
        user.ChangeUserActivation(new UserActivationBuilder().WithValue(isActive).Build());

        var changeEvent = user.AssertPublishedDomainEvent<UserChangeActivationEvent>();

        // assert
        user.DomainEvents.Should().HaveCount(1);
        changeEvent.AggregateId.Should().Be(userId);
        changeEvent.OldValue.Should().BeTrue();
        changeEvent.NewValue.Should().BeFalse();

        user.Id.Value.Should().Be(userId);
        user.IsActive.Value.Should().Be(isActive);
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange

        var userId = Guid.NewGuid();
        var username = "UserUsername";
        var password = "UserPas$w0rd";

        // act
        var user = new UserBuilder()
            .WithId(userId)
            .WithUsername(username)
            .WithPassword(password)
            .Build();

        var createEvent = user.AssertPublishedDomainEvent<UserCreatedEvent>();

        createEvent.AggregateId.Should().Be(userId);
        createEvent.Username.Should().Be(username);

        user.Id.Value.Should().Be(userId);
        user.Username.Value.Should().Be(username);
        user.Password.Value.Should().Be(password);
    }

    [Fact]
    public void TestDelete_WhenEverythingIsOk_MustBeMarkedAsDeleted()
    {
        // arrange
        var user = new UserBuilder().Build();

        user.ClearEvents();

        // act
        user.Delete();

        // assert
        var deletedEvent = user.AssertPublishedDomainEvent<UserDeletedEvent>();
        deletedEvent.AggregateId.Should().Be(user.Id.Value);
        user.CanBeDeleted().Should().BeTrue();
        user.DomainEvents.Should().HaveCount(1);
    }

    [Fact]
    public void TestDelete_WhenAlreadyDeleted_ThrowsException()
    {
        // arrange
        var user = new UserBuilder().Build();
        var deleterId = Guid.NewGuid();
        user.Delete();

        // act
        var action = new Action(() => user.Delete());

        // assert
        action.Should().Throw<InvalidOperationException>();
    }
}