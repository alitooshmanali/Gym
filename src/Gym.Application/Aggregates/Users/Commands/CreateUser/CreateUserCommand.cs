using MediatR;

namespace Gym.Application.Aggregates.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<string>
{
    public string Username { get; set; }

    public string Password { get; set; }
}