namespace NoteIt.Application.Handlers.Users;
public sealed class UpdateHandler : IRequestHandler<UpdateRequest, UserInfo>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateHandler(
        IUserRepository userRepository
        , IMapper mapper
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserInfo> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("User", request.Id);

        _userRepository.Update(user);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserInfo>(user);
    }
}
