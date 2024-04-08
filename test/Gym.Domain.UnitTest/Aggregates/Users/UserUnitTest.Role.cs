using FluentAssertions;
using Gym.Domain.Aggregates.Users.Events;
using Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;
using Gym.Domain.UnitTest.Aggregates.Users.Builders;
using Gym.Domain.UnitTest.Helpers;

namespace Gym.Domain.UnitTest.Aggregates.Users;

public partial class UserUnitTest
{
    [Fact]
    public void TestAddRole_WhenRoleAlreadyExists_NothingMustBeHappened()
    {
        // arrange
        var creatorId = Guid.NewGuid();
        var roleId = new RoleIdBuilder().Build();
        var user = new UserBuilder().Build();

        user.AddRole(roleId, creatorId);
        user.ClearEvents();

        // act
        user.AddRole(roleId, creatorId);

        // assert
        user.DomainEvents.Should().BeEmpty();
    }

    [Fact]
    public void TestAddRole_WhenEverythingIsOk_MustBeAdded()
    {
        // arrange
        var creatorId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var roleId = new RoleIdBuilder().Build();
        var user = new UserBuilder().WithId(userId).Build();
        user.ClearEvents();
        
        // act
        user.AddRole(roleId, creatorId);

        var addedEvent = user.AssertPublishedDomainEvent<UserRoleAddedEvent>();
        
        // assert
        addedEvent.AggregateId.Should().Be(userId);
        addedEvent.RoleId.Should().Be(roleId.Value);
        addedEvent.CreatorId.Should().Be(creatorId);
        user.DomainEvents.Should().HaveCount(1);
    }

    [Fact]
    public void TestRemoveRole_WhenRoleDoesNotExist_NothingMustBeHappened()
    {
        // arrange
        var creatorId = Guid.NewGuid();
        var roleId = new RoleIdBuilder().Build();
        var user = new UserBuilder().Build();

        user.ClearEvents();

        // act
        user.RemoveRole(roleId, creatorId);

        // assert
        user.DomainEvents.Should().BeEmpty();
    }

    [Fact]
    public void TestRemoveRole_WhenEverythingIsOk_MustBeRemoved()
    {
        // arrange
        var removerId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var roleId = new RoleIdBuilder().Build();
        var user = new UserBuilder().WithId(userId).Build();

        user.AddRole(roleId, Guid.NewGuid());
        user.ClearEvents();

        // act
        user.RemoveRole(roleId, removerId);

        var addedEvent = user.AssertPublishedDomainEvent<UserRoleRemovedEvent>();

        // assert
        addedEvent.AggregateId.Should().Be(userId);
        addedEvent.RoleId.Should().Be(roleId.Value);
        addedEvent.RemoverId.Should().Be(removerId);

        user.DomainEvents.Should().HaveCount(1);
    }
}