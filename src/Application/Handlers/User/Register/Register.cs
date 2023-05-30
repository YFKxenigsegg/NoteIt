using Microsoft.AspNetCore.Identity;
using Note.Domain.Consts;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using System.Text;

namespace Note.Application.Handlers.User.Register;
public class RegisterHandler : IRequestHandler<RegisterRequest, string>
{
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterHandler(
        IMapper mapper
        , UserManager<ApplicationUser> userManager
        )
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<string> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByEmailAsync(request.Email) != null)
            throw new AlreadyExistException($"User with \'{request.Email}\' already exist.");

        var user = _mapper.Map<ApplicationUser>(request);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, Roles.User);
            return user.Id;
        }
        else
        {
            var stringBuilder = new StringBuilder();
            foreach (var error in result.Errors)
            {
                stringBuilder.AppendFormat($"-> {error.Description}");
            }
            throw new BadRequestException($"{stringBuilder}");
        }
    }
}
