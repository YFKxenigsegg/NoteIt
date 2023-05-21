using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence;

namespace Note.Application.Handlers.Role.Create;
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
        if (await _dbContext.Roles.AnyAsync(x => x.Name == request.Name, cancellationToken))
            throw new AlreadyExistException($"Role with \'{request.Name}\' already exist.");

        var role = _mapper.Map<ApplicationRole>(request);

        await _dbContext.Roles.AddAsync(role, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return role.Id;
    }
}
