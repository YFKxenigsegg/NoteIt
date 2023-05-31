using NoteIt.Domain.Entities;
using NoteIt.Infrastructure.Mappings;

namespace NoteIt.Infrastructure.Identity;
public class RoleInfo : IMapFrom<ApplicationRole>
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}
