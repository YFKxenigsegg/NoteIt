﻿namespace NoteIt.Application.Handlers.Role;
public sealed class CreateHandler : IRequestHandler<CreateRequest, string>
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

        if (role != null) throw new AlreadyExistException("Role", request.Name);

        role = _mapper.Map<ApplicationRole>(request);

        _roleRepository.Add(role);
        await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return role.Id;
    }
}
