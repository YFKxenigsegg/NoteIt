namespace NoteIt.Application.Handlers.Users;
public sealed class CreateHandler : IRequestHandler<CreateRequest, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateHandler(
        IUserRepository userRepository
        , IMapper mapper
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(request.Email, cancellationToken) != null)
            throw new AlreadyExistException($"User with \'{request.Email}\' already exist");

        var user = _mapper.Map<User>(request);

        _userRepository.Add(user);
        await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
