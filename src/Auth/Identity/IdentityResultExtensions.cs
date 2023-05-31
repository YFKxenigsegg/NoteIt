using Microsoft.AspNetCore.Identity;
using NoteIt.Application.Models;

namespace NoteIt.Auth.Identity;
public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
        => result.Succeeded ? Result.Success() : Result.Failure(result.Errors.Select(x => x.Description));
}
