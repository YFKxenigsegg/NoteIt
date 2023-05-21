using AutoMapper;
using MediatR;
using Note.Domain.Consts;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence;

namespace Note.Application.Users.Register;
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
        var user = _dbContext.Users.FirstOrDefault(x => x.Email == request.Email);

        if (user != null) throw new AlreadyExistException($"User with \'{request.Email}\' already exist.");

        var applicationUser = _mapper.Map<ApplicationUser>(request);
        applicationUser.RoleId = _dbContext.Roles.First(x => x.Name == Roles.User).Id;

        await _dbContext.Users.AddAsync(applicationUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return applicationUser.Id;
    }
}
