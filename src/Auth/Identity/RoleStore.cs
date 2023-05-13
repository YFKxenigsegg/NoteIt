using MediatR;
using Microsoft.AspNetCore.Identity;
using Note.Application.Role;
using Note.Auth.Feature.Role;
using Note.Infrastructure.Identity;

namespace Note.Auth.Identity;
public class RoleStore : IRoleStore<RoleInfo>
{
    private readonly IMediator _mediator;

    public RoleStore(IMediator mediator)
        => _mediator = mediator;
    public async Task<RoleInfo?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        => await _mediator.Send(new GetRequest { Name = normalizedRoleName }, cancellationToken);

    public async Task<RoleInfo?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        => await _mediator.Send(new GetRequest { Id = roleId }, cancellationToken);

    public async Task<IdentityResult> CreateAsync(RoleInfo role, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CreateRequest { Name = role.Name }, cancellationToken);
        return IdentityResult.Success;
    }

    public void Dispose() { }

    public Task<IdentityResult> DeleteAsync(RoleInfo role, CancellationToken cancellationToken)
         => throw new NotImplementedException();

    public Task<string?> GetNormalizedRoleNameAsync(RoleInfo role, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task<string> GetRoleIdAsync(RoleInfo role, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task<string?> GetRoleNameAsync(RoleInfo role, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task SetNormalizedRoleNameAsync(RoleInfo role, string? normalizedName, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task SetRoleNameAsync(RoleInfo role, string? roleName, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task<IdentityResult> UpdateAsync(RoleInfo role, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
