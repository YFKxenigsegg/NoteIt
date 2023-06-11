using System.Net;
using System.Runtime.Serialization;

namespace NoteIt.Application.Exceptions;
[Serializable]
public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    protected BaseException(SerializationInfo info, StreamingContext context)
    : base(info, context) { }

    public BaseException(HttpStatusCode statusCode, string message)
        : base(message) => StatusCode = statusCode;

    public BaseException(HttpStatusCode statusCode, string message, Exception exception)
        : base(message, exception) => StatusCode = statusCode;
}
