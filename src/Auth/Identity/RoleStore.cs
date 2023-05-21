using MediatR;
using Microsoft.AspNetCore.Identity;
using Note.Application.Role.Create;
using Note.Domain.Entities;

namespace Note.Auth.Identity;
public class RoleStore : IRoleStore<ApplicationRole>
{
    private readonly IMediator _mediator;

    public RoleStore(IMediator mediator)
        => _mediator = mediator;
    public async Task<ApplicationRole?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        //=> await _mediator.Send(new GetRequest { Name = normalizedRoleName }, cancellationToken);
        => throw new NotImplementedException();

    public async Task<ApplicationRole?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        //=> await _mediator.Send(new GetRequest { Id = roleId }, cancellationToken);
        => throw new NotImplementedException();

    public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CreateRequest { Name = role.Name }, cancellationToken);
        return IdentityResult.Success;
    }

    public void Dispose() { }

    public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
         => throw new NotImplementedException();

    public Task<string?> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task<string?> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task SetNormalizedRoleNameAsync(ApplicationRole role, string? normalizedName, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task SetRoleNameAsync(ApplicationRole role, string? roleName, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    public Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
