namespace Gym.Application.Aggregates.Users;

public interface IUserReadRepository
{
    IQueryable<UserQueryResult> GetAll();

    Task<UserQueryResult?> GetByUsername(string username, CancellationToken cancellationToken = default);
}