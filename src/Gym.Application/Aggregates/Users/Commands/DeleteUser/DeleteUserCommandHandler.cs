using Gym.Application.Properties;
using Gym.Domain.Exceptions;
using MediatR;
using User = Gym.Domain.Aggreagtes.Users.User;

namespace Gym.Application.Aggregates.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserWriteRepository _writeRepository;

    public DeleteUserCommandHandler(IUserWriteRepository writeRepository)
    {
        _writeRepository = writeRepository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _writeRepository.GetByUsername(request.Username, cancellationToken)
            .ConfigureAwait(false);

        if (user is null)
            throw new DomainException(string.Format(ApplicationResources.Global_UnableToFind, nameof(User)));

        user.Delete();
    }
}