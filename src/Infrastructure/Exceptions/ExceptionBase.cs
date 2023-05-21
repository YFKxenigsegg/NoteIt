using System.Net;

namespace Note.Infrastructure.Exceptions;
public class ExceptionBase : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public ExceptionBase(HttpStatusCode statusCode, string message)
        : base(message) => StatusCode = statusCode;

    public ExceptionBase(HttpStatusCode statusCode, string message, Exception exception)
        : base(message, exception) => StatusCode = statusCode;
}
