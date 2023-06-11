using NoteIt.Application.Abstractions;
using NoteIt.Application.Exceptions;

namespace NoteIt.Application.Handlers.User.Login;
public class LoginHandler : IRequestHandler<LoginRequest, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginHandler(
        IUserRepository userRepository
        , IJwtProvider jwtProvider
        )
    {
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken)
            ?? throw new NotFoundException("User", request.Email);

        throw new NotImplementedException();

        //return _jwtProvider.GenerateJwtToken(user);
    }
}
