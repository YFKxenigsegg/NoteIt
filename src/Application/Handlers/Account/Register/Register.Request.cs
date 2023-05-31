namespace NoteIt.Application.Handlers.Account;
public partial class RegisterRequest : IRequest<Unit>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}
