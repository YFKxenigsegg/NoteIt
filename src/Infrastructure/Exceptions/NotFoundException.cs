namespace NoteIt.Infrastructure.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException() : base() { }

    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception exception)
        : base(message, exception) { }

    public NotFoundException(string name, string key)
        : base($"Entity \'{name}\' ({key}) was not found") { }
}
