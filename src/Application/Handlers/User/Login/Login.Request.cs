namespace NoteIt.Application.Handlers.User.Login;
public class LoginRequest : IRequest<string>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
