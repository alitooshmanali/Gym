namespace Gym.Application.Aggregates.Audits;

public interface IAuditReadRepository
{
    IQueryable<AuditQueryResult> GetAll();
}