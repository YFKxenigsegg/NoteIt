using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NoteIt.Application.Options;
using NoteIt.Infrastructure.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NoteIt.Application.Handlers.Account;
public class LoginHandler : IRequestHandler<LoginRequest, AccountResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public LoginHandler(
        IUserRepository userRepository
        , IJwtService jwtService
        )
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<AccountResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken)
            ?? throw new NotFoundException("User", request.Email);

        var actualHash = user.PasswordHash;
        var hash = new SaltedPasswordHasher().HashPassword(user, request.Password);

        if (actualHash != hash) throw new BadRequestException($"Credentials for '{request.Email}' aren't valid");

        var test = new SaltedPasswordHasher().Verify(request.Password, hash);

        var result = new AccountResponse
        {
            UserId = user.Id,
            Email = user.Email,
            Token = _jwtService.GenerateJwtToken(user)
        };

        return result;
    }
}
