using AutoMapper;
using MediatR;
using Note.Domain.Entities;
using Note.Infrastructure.Persistence;

namespace Note.Application.Role;
public class CreateHandler : IRequestHandler<CreateRequest, string>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateHandler(
        ApplicationDbContext dbContext
        , IMapper mapper
        ) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<string> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<UserRole>(request);

        await _dbContext.Set<UserRole>().AddAsync(role, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return role.Id;
    }
}
