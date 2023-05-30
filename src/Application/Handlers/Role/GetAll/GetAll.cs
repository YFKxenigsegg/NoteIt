namespace Note.Application.Handlers.Role;
public class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<RoleInfo>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public GetAllHandler(
        IRoleRepository roleRepository
        , IMapper mapper
        )
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RoleInfo>> Handle(GetAllRequest request, CancellationToken cancellationToken)
    {
        var notes = _roleRepository.GetAll();
        var result = _mapper.Map<IEnumerable<RoleInfo>>(notes);

        return result;
    }
}
