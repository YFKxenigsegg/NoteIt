using Microsoft.AspNetCore.Identity;

namespace NoteIt.Domain.Entities;
public class ApplicationRole : IdentityRole
{
    public override string Id { get; set; } = default!;
    public override string? Name { get; set; } = default!;
    public DateTime Created { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; } = default!;
}
