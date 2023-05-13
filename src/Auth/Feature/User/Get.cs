using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Identity;
using Note.Infrastructure.Persistence;

namespace Note.Auth.Feature.User;
public class GetHandler : IRequestHandler<GetRequest, UserInfo>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetHandler(
        ApplicationDbContext dbContext
        , IMapper mapper
        ) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UserInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var identifier = request.Id ?? request.Email;

        var result = await _dbContext.Set<UserLogin>()
            .ProjectTo<UserInfo>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == identifier || x.Email == identifier, cancellationToken)
                ?? throw new NotFoundException(request.Id == null ? $"Not found User \'{request.Email}\'" : $"Not found User \'{request.Id}\'");

        return result;
    }
}
