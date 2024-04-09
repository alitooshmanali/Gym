using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Gym.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request
        , RequestHandlerDelegate<TResponse> next
        , CancellationToken cancellationToken)
    {
        var requestName = request.GetType().Name;
        var requestBody = JsonSerializer.Serialize(request);

        try
        {
            _logger.LogInformation($"Handling request {requestName} started. Values: {requestBody}.");
            var response = await next().ConfigureAwait(false);
            _logger.LogInformation($"Handling request {requestName} finished.");

            return response;
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Handling request {requestName} failed.");
            throw;
        }
    }
}