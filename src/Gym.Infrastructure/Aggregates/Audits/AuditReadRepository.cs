using Gym.Application.Aggregates.Audits;
using Microsoft.EntityFrameworkCore;

namespace Gym.Infrastructure.Aggregates.Audits;

public class AuditReadRepository: IAuditReadRepository
{
    private readonly GymReadDbContext _dbContext;

    public AuditReadRepository(GymReadDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IQueryable<AuditQueryResult> GetAll()
    {
        return _dbContext.AuditQueryResults.FromSqlRaw($@"
                SELECT      A.""Id"",
                                A.""AggregateId"",                                
                                COALESCE(U.""Username"", A.""UserId""::TEXT) AS ""User"",                                
                                A.""Action"",
                                A.""Data"",
                                A.""Client"",
                                A.""ClientAddress"",
                                A.""Time""
                    FROM        ""Audits"" AS A
                    LEFT JOIN   ""Users""       AS U   ON A.""UserId""      = U.""Id""");
    }
}