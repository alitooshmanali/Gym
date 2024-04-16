using Gym.Application.Aggregates.Audits;

namespace Gym.Infrastructure.Aggregates.Audits;

public class AuditWriteRepository: IAuditWriteRepository
{
    private readonly GymWriteDbContext _dbContext;

    public AuditWriteRepository(GymWriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Audit audit)
    {
        _dbContext.Audits.Add(audit);
    }
}