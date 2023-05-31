using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NoteIt.Infrastructure.Behaviours;
public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public RequestLogger(ILogger<TRequest> logger)
        => _logger = logger;

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        _logger.LogDebug($"Request {requestName} {JsonConvert.SerializeObject(request)}");
        return Task.CompletedTask;
    }
}
