using Microsoft.AspNetCore.Identity;

namespace Note.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public override string Id { get; set; } = default!;
    public override string Email { get; set; } = default!;
    public override string PasswordHash { get; set; } = default!;
    public DateTime Created { get; set; }
    public DateTime? LastAccess { get; set; }
    public string RoleId { get; set; } = default!;
    public virtual ApplicationRole Role { get; set; } = default!;
}
