using FluentAssertions;
using Gym.Domain.Aggregates.Roles.Events;
using Gym.Domain.Aggregates.Users.Events;
using Gym.Domain.UnitTest.Aggregates.Roles.Builders;
using Gym.Domain.UnitTest.Aggregates.Roles.ValueObjects.Builders;
using Gym.Domain.UnitTest.Aggregates.Users.Builders;
using Gym.Domain.UnitTest.Helpers;

namespace Gym.Domain.UnitTest.Aggregates.Roles;

public class RoleUnitTest
{
    [Fact]
    public void TestChangeName_ValueIsSame_MustBeNotHappened()
    {
        // arrange
        var updaterId = Guid.NewGuid();
        var roleName = new RoleNameBuilder().Build();
        var role = new RoleBuilder()
            .WithName(roleName.Value).Build();

        role.ClearEvents();

        // act
        role.ChangeName(roleName, updaterId);

        // assert
        role.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeName_EverythingIsOk_MustBeChanged()
    {
        // arrange
        const string name = "name";
        var updaterId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
        var roleName = new RoleNameBuilder().WithName(name).Build();
        var role = new RoleBuilder().WithId(roleId).Build();
        var oldValue = role.Name.Value;

        role.ClearEvents();

        // act
        role.ChangeName(roleName, updaterId);

        // assert
        var changedEvent = role.AssertPublishedDomainEvent<NameChangedEvent>();

        changedEvent.AggregateId.Should().Be(roleId);
        changedEvent.OldValue.Should().Be(oldValue);
        changedEvent.NewValue.Should().Be(name);
        changedEvent.UpdaterId.Should().Be(updaterId);

        role.Id.Value.Should().Be(roleId);
        role.Name.Value.Should().Be(name);
    }

    [Fact]
    public void TestChangeDescription_ValueIsSame_MustBeNotHappened()
    {
        // arrange
        var updaterId = Guid.NewGuid();
        var roleDescription = new RoleDescriptionBuilder().Build();
        var role = new RoleBuilder()
            .WithDescription(roleDescription.Value).Build();

        role.ClearEvents();

        // act
        role.ChangeDescription(roleDescription, updaterId);

        // assert
        role.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeDescription_EverythingIsOk_MustBeChanged()
    {
        // arrange
        const string description = "Description";
        var updaterId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
        var roleDescription = new RoleDescriptionBuilder().WithDescription(description).Build();
        var role = new RoleBuilder().WithId(roleId).Build();
        var oldValue = role.Description.Value;

        role.ClearEvents();

        // act
        role.ChangeDescription(roleDescription, updaterId);

        // assert
        var changedEvent = role.AssertPublishedDomainEvent<DescriptionChangedEvent>();

        changedEvent.AggregateId.Should().Be(roleId);
        changedEvent.OldValue.Should().Be(oldValue);
        changedEvent.NewValue.Should().Be(description);
        changedEvent.UpdaterId.Should().Be(updaterId);

        role.Id.Value.Should().Be(roleId);
        role.Description.Value.Should().Be(description);
    }

    [Fact]
    public void TestChangeActivation_ValueIsSame_MustBeNotHappened()
    {
        // arrange
        var updaterId = Guid.NewGuid();
        var roleActivation = new RoleActivationBuilder().Build();
        var role = new RoleBuilder()
            .WithIsActive(roleActivation.Value).Build();

        role.ClearEvents();

        // act
        role.ChangeActivation(roleActivation, updaterId);

        // assert
        role.DomainEvents.Should().HaveCount(0);
    }

    [Fact]
    public void TestChangeActivation_EverythingIsOk_MustBeChanged()
    {
        // arrange
        const bool isActive = false;
        var updaterId = Guid.NewGuid();
        var roleId = Guid.NewGuid();
        var roleActivation = new RoleActivationBuilder().WithActive(isActive).Build();
        var role = new RoleBuilder().WithId(roleId).Build();
        var oldValue = role.IsActive.Value;

        role.ClearEvents();

        // act
        role.ChangeActivation(roleActivation, updaterId);

        // assert
        var changedEvent = role.AssertPublishedDomainEvent<ActivationChangedEvent>();

        changedEvent.AggregateId.Should().Be(roleId);
        changedEvent.OldValue.Should().Be(oldValue);
        changedEvent.NewValue.Should().Be(isActive);
        changedEvent.UpdaterId.Should().Be(updaterId);

        role.Id.Value.Should().Be(roleId);
        role.IsActive.Value.Should().Be(isActive);
    }

    [Fact]
    public void TestCreate_WhenEverythingIsOk_PropertiesShouldHaveCorrectValues()
    {
        // arrange
        var roleId = Guid.NewGuid();
        const string name = "Name";
        const string description = "Description";
        const bool isActive = false;
        var creatorId = Guid.NewGuid();
        var updaterId = Guid.NewGuid();

        // act
        var role = new RoleBuilder()
            .WithId(roleId)
            .WithName(name)
            .WithDescription(description)
            .WithIsActive(isActive)
            .WithCreatorId(creatorId)
            .WithUpdaterId(updaterId)
            .Build();

        var createEvent = role.AssertPublishedDomainEvent<RoleCreatedEvent>();
        var descriptionChangedEvent = role.AssertPublishedDomainEvent<DescriptionChangedEvent>();
        var isActiveChangedEvent = role.AssertPublishedDomainEvent<ActivationChangedEvent>();

        createEvent.AggregateId.Should().Be(roleId);
        createEvent.Name.Should().Be(name);
        createEvent.IsActive.Should().BeTrue();
        createEvent.CreatorId.Should().Be(creatorId);

        descriptionChangedEvent.AggregateId.Should().Be(roleId);
        descriptionChangedEvent.OldValue.Should().BeNull();
        descriptionChangedEvent.NewValue.Should().Be(description);
        descriptionChangedEvent.UpdaterId.Should().Be(updaterId);

        isActiveChangedEvent.AggregateId.Should().Be(roleId);
        isActiveChangedEvent.OldValue.Should().BeTrue();
        isActiveChangedEvent.NewValue.Should().Be(isActive);
        isActiveChangedEvent.UpdaterId.Should().Be(updaterId);

        role.Id.Value.Should().Be(roleId);
        role.Name.Value.Should().Be(name);
        role.Description.Value.Should().Be(description);
        role.IsActive.Value.Should().Be(isActive);
    }

    [Fact]
    public void TestDelete_WhenEverythingIsOk_MustBeMarkedAsDeleted()
    {
        // arrange
        var deleterId = Guid.NewGuid();
        var role = new RoleBuilder().Build();

        role.ClearEvents();

        // act
        role.Delete(deleterId);

        // assert
        var deletedEvent = role.AssertPublishedDomainEvent<RoleDeletedEvent>();
        deletedEvent.AggregateId.Should().Be(role.Id.Value);
        deletedEvent.DeleterId.Should().Be(deleterId);
        role.CanBeDeleted().Should().BeTrue();
        role.DomainEvents.Should().HaveCount(1);
    }

    [Fact]
    public void TestDelete_WhenAlreadyDeleted_ThrowsException()
    {
        // arrange
        var role = new RoleBuilder().Build();
        var deleterId = Guid.NewGuid();
        role.Delete(deleterId);

        // act
        var action = new Action(() => role.Delete(deleterId));

        // assert
        action.Should().Throw<InvalidOperationException>();
    }
}