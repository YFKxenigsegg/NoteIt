using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NoteIt.Application.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NoteIt.Application.Handlers.Account;
public class JwtService : IJwtService
{
    private readonly AuthOptions _authOptions;

    public JwtService(IOptions<AuthOptions> authOptions)
    {
        _authOptions = authOptions.Value;
    }

    public string GenerateJwtToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var symmetricSecurityKey = _authOptions.GetSymmetricSecurityKey();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddMinutes(_authOptions.AccessTokenExpireTimeSpanInMinutes),
            SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string? ValidateJwtToken(string? token)
    {
        if (token == null) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var symmetricSecurityKey = _authOptions.GetSymmetricSecurityKey();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = symmetricSecurityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

            return userId;
        }
        catch
        {
            return null;
        }
    }
}
