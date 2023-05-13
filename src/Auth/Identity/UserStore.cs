using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Note.Application.Users.Users;
using Note.Auth.Feature.User;
using Note.Domain.Entities;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Identity;
using Note.Infrastructure.Persistence;

namespace Note.Auth.Identity;
public class UserStore :
    IUserStore<UserInfo>
    , IUserPasswordStore<UserInfo>
    , IUserLockoutStore<UserInfo>
    , IUserRoleStore<UserInfo>
    , IUserEmailStore<UserInfo>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserStore(
        ApplicationDbContext dbContext
        , IMapper mapper
        , IMediator mediator
        ) => (_dbContext, _mapper, _mediator) = (dbContext, mapper, mediator);

    public async Task<UserInfo?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        => await _mediator.Send(new GetRequest { Email = normalizedEmail }, cancellationToken);

    public async Task<UserInfo?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        => await _mediator.Send(new GetRequest { Id = userId }, cancellationToken);

    public async Task<IdentityResult> CreateAsync(UserInfo user, CancellationToken cancellationToken)
    {
        if(user == null) throw new ArgumentNullException(nameof(user));

        await _dbContext.as

        return IdentityResult.Success;
    }

    public async Task AddToRoleAsync(UserInfo userInfo, string roleName, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Set<UserLogin>()
            .FirstOrDefaultAsync(x => x.Id == userInfo.Id, cancellationToken)
                ?? throw new NotFoundException($"Not found User \'{userInfo.Id}\'");

        var role = await _dbContext.Set<UserRole>()
            .FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken)
                ?? throw new NotFoundException($"Not found Role \'{roleName}\'");

        user.Role = role;
        
        _dbContext.Set<UserLogin>().Update(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() { }

    public Task<IdentityResult> DeleteAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserInfo?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetAccessFailedCountAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetEmailAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetEmailConfirmedAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> GetLockoutEnabledAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DateTimeOffset?> GetLockoutEndDateAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedEmailAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedUserNameAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetPasswordHashAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<string>> GetRolesAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetUserNameAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<UserInfo>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasPasswordAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> IncrementAccessFailedCountAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(UserInfo user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFromRoleAsync(UserInfo user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task ResetAccessFailedCountAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetEmailAsync(UserInfo user, string? email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetEmailConfirmedAsync(UserInfo user, bool confirmed, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetLockoutEnabledAsync(UserInfo user, bool enabled, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetLockoutEndDateAsync(UserInfo user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedEmailAsync(UserInfo user, string? normalizedEmail, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(UserInfo user, string? normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetPasswordHashAsync(UserInfo user, string? passwordHash, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(UserInfo user, string? userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(UserInfo user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
