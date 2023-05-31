using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NoteIt.Domain.Entities;
using NoteIt.Infrastructure.Exceptions;
using NoteIt.Infrastructure.Identity;
using NoteIt.Infrastructure.Persistence;

namespace NoteIt.Auth.Feature.User;
public class GetHandler : IRequestHandler<GetRequest, ApplicationUser>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetHandler(
        ApplicationDbContext dbContext
        , IMapper mapper
        ) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ApplicationUser> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var identifier = request.Id ?? request.Email;

        var result = await _dbContext.Set<ApplicationUser>()
            //.ProjectTo<UserInfo>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == identifier || x.Email == identifier, cancellationToken)
                ?? throw new NotFoundException(request.Id == null ? $"Not found User \'{request.Email}\'" : $"Not found User \'{request.Id}\'");

        return result;
    }
}
