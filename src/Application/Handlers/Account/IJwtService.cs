namespace NoteIt.Application.Handlers.Account;
public interface IJwtService
{
    string GenerateJwtToken(ApplicationUser user);
    string? ValidateJwtToken(string? token);
}
