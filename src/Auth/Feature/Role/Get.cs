using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NoteIt.Domain.Entities;
using NoteIt.Infrastructure.Exceptions;
using NoteIt.Infrastructure.Identity;
using NoteIt.Infrastructure.Persistence;

namespace NoteIt.Auth.Feature.Role;
public class GetHandler : IRequestHandler<GetRequest, RoleInfo>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetHandler(
        ApplicationDbContext dbContext
        , IMapper mapper
        ) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<RoleInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var identifier = request.Id ?? request.Name;

        var result = await _dbContext.Set<ApplicationRole>()
            .ProjectTo<RoleInfo>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == identifier || x.Name == identifier, cancellationToken)
                ?? throw new NotFoundException(request.Id == null ? $"Not found Role \'{request.Name}\'" : $"Not found Role \'{request.Id}\'");

        return result;
    }
}
