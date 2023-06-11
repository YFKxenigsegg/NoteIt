using System.Runtime.Serialization;

namespace NoteIt.Application.Exceptions;
[Serializable]
public class AlreadyExistException : Exception
{
    protected AlreadyExistException(SerializationInfo info, StreamingContext context)
    : base(info, context) { }

    public AlreadyExistException() : base() { }

    public AlreadyExistException(string message) : base(message) { }

    public AlreadyExistException(string message, Exception exception)
        : base(message, exception) { }

    public AlreadyExistException(string name, string key)
        : base($"Entity \'{name}\' ({key}) already exist.") { }
}
