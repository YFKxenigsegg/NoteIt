using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NoteIt.Application.Handlers.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NoteIt.Infrastructure.Authentication;
public sealed class JwtProvider : IJwtProvider
{
    private readonly AuthOptions _authOptions;

    public JwtProvider(IOptions<AuthOptions> authOptions)
    {
        _authOptions = authOptions.Value;
    }

    public JwtInfo GenerateJwt(User user)
    {
        var symmetricSecurityKey = _authOptions.GetSymmetricSecurityKey();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(_authOptions.AccessTokenExpireTimeSpanInMinutes),
            SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtInfo = new JwtInfo { Token = tokenHandler.WriteToken(token), Expiration = token.ValidTo };

        return jwtInfo;
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
