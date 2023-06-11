using Microsoft.AspNetCore.Identity;
using NoteIt.Domain.Consts;

namespace NoteIt.Application.Handlers.Authentication.Register;
public class RegisterHandler : IRequestHandler<RegisterRequest, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterHandler(
        IUserRepository userRepository
        , IRoleRepository roleRepository
        , UserManager<ApplicationUser> userManager
        )
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user != null) throw new AlreadyExistException("User", request.Email);

        user = new ApplicationUser
        {
            UserName = request.UserName,
            Email = request.Email,
            Created = DateTime.UtcNow,
            RoleId = (await _roleRepository.GetByNameAsync(Roles.User, cancellationToken))!.Id
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();
            throw new BadRequestException("Something wrong");
        }

        return Unit.Value;
    }
}
