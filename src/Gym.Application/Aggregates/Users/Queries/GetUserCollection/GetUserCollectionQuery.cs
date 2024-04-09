using MediatR;

namespace Gym.Application.Aggregates.Users.Queries.GetUserCollection;

public class GetUserCollectionQuery : BaseCollectionQuery, IRequest<BaseCollectionQueryResult<UserQueryResult>>
{
}