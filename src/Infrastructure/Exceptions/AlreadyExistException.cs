namespace NoteIt.Infrastructure.Exceptions;
public class AlreadyExistException : Exception
{
    public AlreadyExistException() : base() { }

    public AlreadyExistException(string message) : base(message) { }

    public AlreadyExistException(string message, Exception exception)
        : base(message, exception) { }

    public AlreadyExistException(string name, string key)
        : base($"Entity \'{name}\' ({key}) already exist.") { }
}
