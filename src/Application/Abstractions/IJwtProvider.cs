namespace NoteIt.Application.Abstractions;
public interface IJwtProvider
{
    string GenerateJwtToken(ApplicationUser user);
    string? ValidateJwtToken(string? token);
}
