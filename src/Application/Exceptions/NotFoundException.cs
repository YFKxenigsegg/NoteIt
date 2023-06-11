using System.Runtime.Serialization;

namespace NoteIt.Application.Exceptions;
[Serializable]
public class NotFoundException : Exception
{
    protected NotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public NotFoundException() : base() { }

    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception exception)
        : base(message, exception) { }

    public NotFoundException(string name, string key)
        : base($"Entity \'{name}\' ({key}) was not found") { }
}
