using Microsoft.AspNetCore.Identity;

namespace Note.Domain.Entities;
public class UserLogin : IdentityUser<string>
{
    public override string Id { get; set; } = default!;
    public override string Email { get; set; } = default!;
    public override string PasswordHash { get; set; } = default!;
    public override string PhoneNumber { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime Created { get; set; }
    public DateTime? LastAccess { get; set; }
    public string RoleId { get; set; } = default!;
    public virtual UserRole Role { get; set; } = default!;
}
