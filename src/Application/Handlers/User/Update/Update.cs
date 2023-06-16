namespace NoteIt.Application.Handlers.User;
public sealed class UpdateHandler : IRequestHandler<UpdateRequest, UserInfo>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public UpdateHandler(
        IUserRepository userRepository
        , IRoleRepository roleRepository
        , IMapper mapper
        )
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<UserInfo> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("User", request.Id);

        var role = await _roleRepository.GetByNameAsync(request.RoleName, cancellationToken)
            ?? throw new NotFoundException("Role", request.RoleName);

        user.RoleId = role.Id;

        _userRepository.Update(user);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserInfo>(user);
    }
}
