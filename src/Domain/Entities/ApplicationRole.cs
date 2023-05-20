using Microsoft.AspNetCore.Identity;

namespace Note.Domain.Entities;
public class ApplicationRole : IdentityRole
{
    public override string Id { get; set; } = default!;
    public override string Name { get; set; } = default!;
    public IEnumerable<ApplicationUser> Users { get; set; } = default!;
}
