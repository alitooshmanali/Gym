using MediatR;

namespace Gym.Application.Aggregates.Audits.Queries.GetAuditCollection;

public class GetAuditCollectionQuery: BaseCollectionQuery, IRequest<BaseCollectionQueryResult<AuditQueryResult>>
{
    
}