using MediatR;

namespace Gym.Application.Aggregates.Audits.Queries.GetAuditCollection;

public class GetAuditCollectionQueryHandler : IRequestHandler<GetAuditCollectionQuery, BaseCollectionQueryResult<AuditQueryResult>>
{
    private readonly IAuditReadRepository _readRepository;

    public GetAuditCollectionQueryHandler(IAuditReadRepository readRepository)
    {
        _readRepository = readRepository;
    }
    public Task<BaseCollectionQueryResult<AuditQueryResult>> Handle(GetAuditCollectionQuery request, CancellationToken cancellationToken)
    {
        var source = _readRepository.GetAll().OrderByDescending(i => i.Time);
        var paging = source.Expression.ApplyPaging(request.PageSize, request.PageIndex);
        var totalRecord = source.Expression.ApplyTotalCount();

        return Task.FromResult(new BaseCollectionQueryResult<AuditQueryResult>
        {
            Result = source.Provider.CreateQuery<AuditQueryResult>(paging).ToArray(),
            TotalCount = totalRecord.Invoke<long>()
        });
    }
}