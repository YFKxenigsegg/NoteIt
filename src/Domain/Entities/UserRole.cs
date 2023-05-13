using Microsoft.AspNetCore.Identity;

namespace Note.Domain.Entities;
public class UserRole : IdentityRole<string>
{
    public override string Id { get; set; } = default!;
    public override string Name { get; set; } = default!;
    public IEnumerable<UserLogin> Users { get; set; } = default!;
}
