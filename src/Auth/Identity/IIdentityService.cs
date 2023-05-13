using Note.Application.Models;

namespace Note.Auth.Identity;
public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> AuthorizeAsync(string userId, string policyName);
    Task<(Result result, string UserId)> CreateUserAsync(string userName, string password);
    Task<Result> DeleteUserAsync(string userId);
}
