using NoteIt.Application.Handlers.Authentication;

namespace NoteIt.Application.Abstractions;
public interface IJwtProvider
{
    JwtInfo GenerateJwt(User user);
    string? ValidateJwtToken(string? token);
}
