using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.Domain.Consts;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence;

namespace Note.Application.Handlers.User.Register;
public class RegisterHandler : IRequestHandler<RegisterRequest, string>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public RegisterHandler(
        ApplicationDbContext dbContext
        , IMapper mapper
        ) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<string> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        if (await _dbContext.Users.AnyAsync(x => x.Email == request.Email, cancellationToken))
            throw new AlreadyExistException($"User with \'{request.Email}\' already exist.");

        var user = _mapper.Map<ApplicationUser>(request);
        user.RoleId = _dbContext.Roles.First(x => x.Name == Roles.User).Id;

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
