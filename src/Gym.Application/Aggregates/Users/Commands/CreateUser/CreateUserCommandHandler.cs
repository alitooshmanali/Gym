using Gym.Domain.Aggregates.Users;
using Gym.Domain.Aggregates.Users.ValueObjects;
using MediatR;

namespace Gym.Application.Aggregates.Users.Commands.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, string>
{
    private readonly IUserWriteRepository _writeRepository;

    public CreateUserCommandHandler(IUserWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid();
        var user = User.Create(UserId.Create(userId),
            Username.Create(request.Username),
            UserPassword.Create(request.Password),
            UserActivation.Create(true),
            request.CreatorId);

        _writeRepository.Add(user);

        return Task.FromResult(request.Username);
    }
}