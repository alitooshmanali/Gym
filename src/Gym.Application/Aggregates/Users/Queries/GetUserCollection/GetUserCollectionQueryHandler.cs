using MediatR;

namespace Gym.Application.Aggregates.Users.Queries.GetUserCollection;

public class GetUserCollectionQueryHandler: IRequestHandler<GetUserCollectionQuery, BaseCollectionQueryResult<UserQueryResult>>
{
    private readonly IUserReadRepository _readRepository;

    public GetUserCollectionQueryHandler(IUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public Task<BaseCollectionQueryResult<UserQueryResult>> Handle(GetUserCollectionQuery request, CancellationToken cancellationToken)
    {
        var source = _readRepository.GetAll().OrderBy(i => i.Username);
        var paging = source.Expression.ApplyPaging(request.PageSize, request.PageIndex);
        var totalRecord = source.Expression.ApplyTotalCount();

        return Task.FromResult(new BaseCollectionQueryResult<UserQueryResult>
        {
            Result = source.Provider.CreateQuery<UserQueryResult>(paging).ToArray(),
            TotalCount = totalRecord.Invoke<long>()
        });
    }
}