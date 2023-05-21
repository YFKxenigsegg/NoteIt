using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence;

namespace Note.Application.Handlers.User.Create;
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
        if (await _dbContext.Users.AnyAsync(x => x.Email == request.Email, cancellationToken))
            throw new AlreadyExistException($"User with \'{request.Email}\' already exist.");

        var user = _mapper.Map<ApplicationUser>(request);
        user.RoleId = (await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == request.RoleName, cancellationToken))?.Id
            ?? throw new NotFoundException("Role", request.RoleName);

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
