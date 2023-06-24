namespace NoteIt.Application.Handlers.Authentication;
public class RegisterRequest : IRequest<Unit>
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}
