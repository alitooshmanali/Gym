using MediatR;

namespace Gym.Application.Aggregates.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public string Username { get; set; }

    public Guid DeleterId { get; set; }
}