namespace NoteIt.Application.Handlers.Authentication;
public class LoginRequest : IRequest<JwtInfo>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
