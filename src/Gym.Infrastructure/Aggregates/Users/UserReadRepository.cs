using Gym.Application.Aggregates.Users;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infrastructure.Aggregates.Users;

public class UserReadRepository: IUserReadRepository
{
    private readonly GymReadDbContext _dbContext;

    public UserReadRepository(GymReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<UserQueryResult> GetAll()
    {
        return _dbContext.UserQueryResults.FromSqlRaw($@"
                    SELECT      U.""Id"",
                                U.""Username"",
                                U.""Description"",
                                U.""IsActive"",
                                U.""Created"",
                                U.""Updated"",
                                U.""Version""
                    FROM        ""Users"" AS U");
    }

    public async Task<UserQueryResult?> GetByUsername(string username, CancellationToken cancellationToken = default)
    {
        return await _dbContext.UserQueryResults.FromSqlRaw($@"
                    SELECT      U.""Id"",
                                U.""Username"",
                                U.""Description"",
                                U.""IsActive"",
                                U.""Created"",
                                U.""Updated"",
                                U.""Version""
                    FROM        ""Users"" AS U
                    WHERE       U.""Username"" = {{0}}
                ", username)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}