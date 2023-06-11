using FluentValidation.Results;
using System.Runtime.Serialization;

namespace NoteIt.Application.Exceptions;
[Serializable]
public class BadRequestException : Exception
{
    public IDictionary<string, string[]>? ValidationErrors { get; set; }

    protected BadRequestException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public BadRequestException() : base() { }

    public BadRequestException(string message) : base(message) { }

    public BadRequestException(string message, ValidationResult validationResult)
        : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
}
