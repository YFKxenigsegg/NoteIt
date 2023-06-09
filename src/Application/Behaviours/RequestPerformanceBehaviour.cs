﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace NoteIt.Application.Behaviours;
public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _timer;

    public RequestPerformanceBehaviour(
        ILogger<TRequest> logger
        ) => (_logger, _timer) = (logger, new());

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        if (elapsedMilliseconds < 500) return response;

        var requestName = typeof(TRequest).Name;
        _logger.LogWarning($"Long running request: {requestName} {elapsedMilliseconds} {JsonConvert.SerializeObject(request)}");
        return response;
    }
}
