using AutoMapper;
using MediatR;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;

namespace Note.Application.Handlers.User;
public class CreateHandler : IRequestHandler<CreateRequest, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public CreateHandler(
        IUserRepository userRepository
        , IRoleRepository roleRepository
        , IMapper mapper
        )
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(request.Email, cancellationToken) != null)
            throw new AlreadyExistException($"User with \'{request.Email}\' already exist.");

        var role = (await _roleRepository.GetByNameAsync(request.RoleName, cancellationToken))
            ?? throw new NotFoundException("Role", request.RoleName);

        var user = _mapper.Map<ApplicationUser>(request);
        user.RoleId = role.Id;

        _userRepository.Add(user);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
