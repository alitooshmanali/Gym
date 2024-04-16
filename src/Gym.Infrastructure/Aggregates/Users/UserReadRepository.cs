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
                                COALESCE(UC.""Username"", U.""CreatorId""::TEXT) AS ""Creator"",
                                COALESCE(UU.""Username"", U.""UpdaterId""::TEXT) AS ""Updater"",
                                U.""Created"",
                                U.""Updated"",
                                U.""Version""
                    FROM        ""Users"" AS U
                    LEFT JOIN   ""Users""       AS UC   ON U.""CreatorId""      = UC.""Id""
                    LEFT JOIN   ""Users""       AS UU   ON U.""UpdaterId""      = UU.""Id""
                ");
    }

    public async Task<UserQueryResult?> GetByUsername(string username, CancellationToken cancellationToken = default)
    {
        return await _dbContext.UserQueryResults.FromSqlRaw($@"
                    SELECT      U.""Id"",
                                U.""Username"",
                                U.""Description"",
                                U.""IsActive"",
                                COALESCE(UC.""Username"", U.""CreatorId""::TEXT) AS ""Creator"",
                                COALESCE(UU.""Username"", U.""UpdaterId""::TEXT) AS ""Updater"",
                                U.""Created"",
                                U.""Updated"",
                                U.""Version""
                    FROM        ""Users"" AS U
                    LEFT JOIN   ""Users""       AS UC   ON U.""CreatorId""      = UC.""Id""
                    LEFT JOIN   ""Users""       AS UU   ON U.""UpdaterId""      = UU.""Id""
                    WHERE       U.""Username"" = {{0}}
                ", username)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}