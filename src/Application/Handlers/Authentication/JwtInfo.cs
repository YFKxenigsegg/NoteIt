namespace NoteIt.Application.Handlers.Authentication;
public class JwtInfo
{
    public required string Token { get; set; }
    public DateTime Expiration { get; set; }
}
