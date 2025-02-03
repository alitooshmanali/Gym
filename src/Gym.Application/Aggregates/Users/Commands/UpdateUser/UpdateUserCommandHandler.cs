using Gym.Application.Properties;
using Gym.Domain.Aggregates.Users.ValueObjects;
using Gym.Domain.Exceptions;
using MediatR;
using User = Gym.Domain.Aggreagtes.Users.User;

namespace Gym.Application.Aggregates.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserWriteRepository _writeRepository;

    public UpdateUserCommandHandler(IUserWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _writeRepository.GetByUsername(request.CurrentUsername, cancellationToken)
            .ConfigureAwait(false);

        if (user is null)
            throw new DomainException(string.Format(ApplicationResources.Global_UnableToFind, nameof(User)));

        user.ChangeUsername(Username.Create(request.Username));
    }
}