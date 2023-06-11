namespace NoteIt.Auth.Identity;
public class ApplicationUserStore : IUserPasswordStore<ApplicationUser>
{
    private readonly IUserRepository _userRepository;

    public ApplicationUserStore(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        _userRepository.Add(user);
        _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return Task.FromResult(IdentityResult.Success);
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        var usr = await _userRepository.GetAsync(user.Id, cancellationToken);
        if (usr != null)
        {
            usr.Email = user.Email;
            usr.PasswordHash = user.PasswordHash;
            usr.Modified = DateTime.UtcNow;
            usr.RoleId = user.RoleId;
        }
        return IdentityResult.Success;
    }

    public void Dispose() { }

    public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        return _userRepository.GetAsync(userId, cancellationToken);
    }

    public Task<ApplicationUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(ApplicationUser user, string? normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetUserNameAsync(ApplicationUser user, string? userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash != null);
    }

    public Task SetPasswordHashAsync(ApplicationUser user, string? passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }
}
