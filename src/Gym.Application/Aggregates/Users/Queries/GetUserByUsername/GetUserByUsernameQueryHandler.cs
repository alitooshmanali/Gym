using MediatR;

namespace Gym.Application.Aggregates.Users.Queries.GetUserByUsername;

public class GetUserByUsernameQueryHandler: IRequestHandler<GetUserByUsernameQuery, UserQueryResult>
{
    private readonly IUserReadRepository _readRepository;

    public GetUserByUsernameQueryHandler(IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public Task<UserQueryResult> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        => _readRepository.GetByUsername(request.Username, cancellationToken);
}