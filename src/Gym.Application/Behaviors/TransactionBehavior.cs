using MediatR;

namespace Gym.Application.Behaviors;

public class TransactionBehavior<TRequest,TResponse>: IPipelineBehavior<TRequest,TResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request
        , RequestHandlerDelegate<TResponse> next
        , CancellationToken cancellationToken)
    {
        if (request.GetType().Name.StartsWith("Get"))
            return await next().ConfigureAwait(false);

        try
        {
            await _unitOfWork.BeginTransaction(cancellationToken).ConfigureAwait(false);
            var response = await next().ConfigureAwait(false);
            await _unitOfWork.CommitTransaction(cancellationToken).ConfigureAwait(false);

            return response;
        }
        catch
        {
            await _unitOfWork.RollbackTransaction(cancellationToken).ConfigureAwait(false);
            throw;
        }
    }
}