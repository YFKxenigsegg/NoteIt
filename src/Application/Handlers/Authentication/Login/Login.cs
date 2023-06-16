using Microsoft.AspNetCore.Identity;
using NoteIt.Application.Abstractions;

namespace NoteIt.Application.Handlers.Authentication.Login;
public sealed class LoginHandler : IRequestHandler<LoginRequest, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginHandler(
        IUserRepository userRepository
        , IJwtProvider jwtProvider
        , UserManager<ApplicationUser> userManager
        )
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
        _userManager = userManager;
    }

    public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken)
            ?? throw new NotFoundException("User", request.Email);

        if (await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return _jwtProvider.GenerateJwtToken(user);
        }
        throw new BadRequestException("Invalid password");
    }
}
