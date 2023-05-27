using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Note.Infrastructure.Exceptions.Filter;
public class ApiExceptionFilter : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            //{ typeof(BadRequestException), HandlerAuthenticationException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(AlreadyExistException), HandleAlreadyExistException },
            { typeof(ValidationException), HandleValidationException },
            { typeof(ExceptionBase), HandleExceptionBse }
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

    //private void HandlerAuthenticationException(ExceptionContext context)
    //{
    //    var exception = context.Exception as BadRequestException;
    //    var details = new ProblemDetails()
    //    {
    //        Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
    //        Title = "Request has not been completed because it lacks valid authentication credentials.",
    //        Detail = exception!.Message
    //    };
    //    context.Result = new UnauthorizedObjectResult(details);
    //    context.ExceptionHandled = true;
    //}

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

    private void HandleAlreadyExistException(ExceptionContext context)
    {
        var exception = context.Exception as AlreadyExistException;
        var details = new ProblemDetails()
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = "Server cannot not process the request.",
            Detail = exception!.Message
        };
        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var exception = context.Exception as ValidationException;
        var details = new ValidationProblemDetails(exception!.Errors)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };
        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private void HandleExceptionBse(ExceptionContext context)
    {
        var exception = context.Exception as ExceptionBase;
        ProblemDetails details;
        switch (exception?.StatusCode)
        {
            case HttpStatusCode.NotFound:
                details = new()
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    Title = "The specified resource was not found.",
                    Detail = exception.Message
                };
                context.Result = new NotFoundObjectResult(details);
                context.ExceptionHandled = true;
                break;
            case HttpStatusCode.BadRequest:
                details = new()
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Detail = exception.Message
                };
                context.Result = new BadRequestObjectResult(details);
                context.ExceptionHandled = true;
                break;
            case HttpStatusCode.Forbidden:
                details = new()
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Detail = exception.Message
                };
                context.Result = new ObjectResult(details);
                context.ExceptionHandled = true;
                break;
        }
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
