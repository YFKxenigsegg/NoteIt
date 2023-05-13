namespace Note.Infrastructure.Exceptions;
public class RegistrationException : Exception
{
    public RegistrationException() : base() { }

    public RegistrationException(string message) : base(message) { }

    public RegistrationException(string message, Exception exception)
        : base(message, exception) { }
}
