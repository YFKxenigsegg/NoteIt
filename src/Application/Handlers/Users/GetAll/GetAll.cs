namespace NoteIt.Application.Handlers.Users;
public sealed class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<UserInfo>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllHandler(
        IUserRepository userRepository
        , IMapper mapper
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<IEnumerable<UserInfo>> Handle(GetAllRequest request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAll();
        var result = _mapper.Map<IEnumerable<UserInfo>>(users);
        return Task.FromResult(result);
    }
}
