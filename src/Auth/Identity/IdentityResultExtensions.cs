using Microsoft.AspNetCore.Identity;
using Note.Application.Models;

namespace Note.Auth.Identity;
public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
        => result.Succeeded ? Result.Success() : Result.Failure(result.Errors.Select(x => x.Description));
}
