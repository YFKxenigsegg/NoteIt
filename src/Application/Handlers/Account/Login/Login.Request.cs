using NoteIt.Application.Handlers.Account;

namespace NoteIt.Application.Handlers.Account;
public class LoginRequest : IRequest<AccountResponse>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
