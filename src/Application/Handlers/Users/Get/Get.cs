namespace NoteIt.Application.Handlers.Users;
public sealed class GetHandler : IRequestHandler<GetRequest, UserInfo>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetHandler(
        IUserRepository userRepository
        , IMapper mapper
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("User", request.Id);

        var result = _mapper.Map<UserInfo>(user);
        return result;
    }
}
