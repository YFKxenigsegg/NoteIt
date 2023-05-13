using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Note.Application.Options;
public class AuthOptions
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string Key { get; set; } = default!;
    public int AccessTokenExpireTimeSpanInMinutes { get; set; }
    public int RefreshTokenExpireTimeSpanInMinutes { get; set; }
    public bool AllowInsecureTokenRequest { get; set; }
    public bool WindowsAuthEnabled { get; set; }
    public string WindowsAuthServerUrl { get; set; } = default!;

    public SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new(Encoding.ASCII.GetBytes(Key));
}
