using AutoMapper;
using MediatR;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;

namespace Note.Application.Handlers.Role;
public class GetHandler : IRequestHandler<GetRequest, RoleInfo>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public GetHandler(
        IRoleRepository roleRepository
        , IMapper mapper
        )
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<RoleInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Role", request.Id);

        var result = _mapper.Map<RoleInfo>(role);
        return result;
    }
}
