using MediatR;

namespace Gym.Application.Aggregates.Users.Queries.GetUserByUsername;

public class GetUserByUsernameQuery: IRequest<UserQueryResult>
{
    public string Username { get; set; }
}