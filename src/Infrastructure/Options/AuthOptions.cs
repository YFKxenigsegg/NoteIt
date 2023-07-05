using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NoteIt.Infrastructure.Options;
public class AuthOptions
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string Key { get; set; } = default!;
    public int AccessTokenExpireTimeSpanInMinutes { get; set; }
    public int RefreshTokenExpireTimeSpanInMinutes { get; set; }

    public SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new(Encoding.UTF8.GetBytes(Key));
}
