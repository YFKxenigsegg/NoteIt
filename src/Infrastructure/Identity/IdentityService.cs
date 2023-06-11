using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteIt.Application.Models;
using NoteIt.Domain.Entities;

namespace NoteIt.Auth.Identity;
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager
        , IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory
        , IAuthorizationService authorizationService
        ) => (_userManager, _userClaimsPrincipalFactory, _authorizationService) = (userManager, userClaimsPrincipalFactory, authorizationService);

    public async Task<string> GetUserNameAsync(string userId)
        => (await _userManager.Users.FirstAsync(x => x.Id == userId)).UserName!;

    public async Task<(Result result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser { UserName = userName, Email = userName };
        var result = await _userManager.CreateAsync(user, password);
        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(x => x.Id == userId);

        if (user == null) return false;

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
        var result = await _authorizationService.AuthorizeAsync(principal, policyName);
        return result.Succeeded;
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(x => x.Id == userId);
        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(x => x.Id == userId);
        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);
        return result.ToApplicationResult();
    }
}
