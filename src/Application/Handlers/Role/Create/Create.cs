using AutoMapper;
using MediatR;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;

namespace Note.Application.Handlers.Role;
public class CreateHandler : IRequestHandler<CreateRequest, string>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public CreateHandler(
        IRoleRepository roleRepository
        , IMapper mapper
        )
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByNameAsync(request.Name, cancellationToken);

        if (role != null) throw new AlreadyExistException("\'Role\'", request.Name);

        role = _mapper.Map<ApplicationRole>(request);

        _roleRepository.Add(role);
        await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return role.Id;
    }
}
