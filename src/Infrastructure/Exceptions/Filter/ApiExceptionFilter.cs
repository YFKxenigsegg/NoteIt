﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Note.Infrastructure.Exceptions.Filter;
public class ApiExceptionFilter : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(AuthenticationException), HandlerAuthorizeException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(RegistrationException), HandleRegistrationException }
        };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        UnknownExceptionHander(context);
    }

    private void HandlerAuthorizeException(ExceptionContext context)
    {
        var exception = context.Exception as AuthenticationException;
        var details = new ProblemDetails()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
            Title = "Request has not been completed because it lacks valid authentication credentials.",
            Detail = exception!.Message
        };
        context.Result = new UnauthorizedObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        var exception = context.Exception as NotFoundException;
        var details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception!.Message
        };
        context.Result = new NotFoundObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleRegistrationException(ExceptionContext context)
    {
        var exception = context.Exception as RegistrationException;
        var details = new ProblemDetails()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = "Server cannot not process the request.",
            Detail = exception!.Message
        };
        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void UnknownExceptionHander(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occured while processing your request.",
            Extensions = { { "exception", context.Exception.Message }, { "stackrace", context.Exception.StackTrace } }
        };
        context.Result = new ObjectResult(details);
        context.ExceptionHandled = true;
    }
}