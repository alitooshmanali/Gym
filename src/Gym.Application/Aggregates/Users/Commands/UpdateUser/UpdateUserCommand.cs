using MediatR;

namespace Gym.Application.Aggregates.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public string CurrentUsername { get; set; }

    public string Username { get; set; }

    public Guid UpdaterId { get; set; }
}