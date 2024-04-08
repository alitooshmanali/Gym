using Gym.Domain.Aggregates.Roles;
using Gym.Domain.Aggregates.Roles.ValueObjects;
using Gym.Domain.Aggregates.ValueObjects;

namespace Gym.Domain.UnitTest.Aggregates.Roles.Builders;

public class RoleBuilder
{
    private Guid _id;

    private string _name;

    private string _description;

    private bool _isActive;

    private Guid _updaterId;

    private Guid _creatorId;

    public RoleBuilder()
    {
        _id = Guid.NewGuid();
        _creatorId = Guid.NewGuid();
        _updaterId = Guid.NewGuid();
        _name = "RoleName";
        _description = "RoleDescription";
        _isActive = true;
    }

    public RoleBuilder WithId(Guid value)
    {
        _id = value;

        return this;
    }

    public RoleBuilder WithName(string value)
    {
        _name = value;

        return this;
    }

    public RoleBuilder WithDescription(string value)
    {
        _description = value;

        return this;
    }

    public RoleBuilder WithIsActive(bool value)
    {
        _isActive = value;

        return this;
    }

    public RoleBuilder WithCreatorId(Guid value)
    {
        _creatorId = value;

        return this;
    }

    public RoleBuilder WithUpdaterId(Guid value)
    {
        _updaterId = value;

        return this;
    }

    public Role Build()
    {
        var role = Role.Create(RoleId.Create(_id), Name.Create(_name), _creatorId);

        role.ChangeDescription(Description.Create(_description), _updaterId);
        role.ChangeActivation(RoleActivation.Create(_isActive), _updaterId);

        return role;
    }
}