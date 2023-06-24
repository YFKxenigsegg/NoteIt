using NoteIt.Application.Abstractions;

namespace NoteIt.Application.Handlers.Authentication;
public sealed class LoginHandler : IRequestHandler<LoginRequest, JwtInfo>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<User> _userManager;

    public LoginHandler(
        IJwtProvider jwtProvider
        , UserManager<User> userManager
        )
    {
        _jwtProvider = jwtProvider;
        _userManager = userManager;
    }

    public async Task<JwtInfo> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email)
            ?? throw new NotFoundException("User", request.Email);

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new BadRequestException("Invalid password");
        }

        return _jwtProvider.GenerateJwt(user);
    }
}
