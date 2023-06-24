using Microsoft.AspNetCore.Identity;

namespace NoteIt.Application.Handlers.Authentication;
public sealed class RegisterHandler : IRequestHandler<RegisterRequest, Unit>
{
    private readonly UserManager<User> _userManager;

    public RegisterHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user != null) throw new AlreadyExistException("User", request.Email);

        user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            Created = DateTime.UtcNow,
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            //
            var errors = result.Errors.Select(x => x.Description).ToList();
            throw new BadRequestException("Something wrong");
        }

        return Unit.Value;
    }
}
