using NoteIt.Application.Common;
using NoteIt.Application.Mappings;
using NoteIt.Domain.Entities;

namespace NoteIt.Application.Handlers.Role;
public class RoleInfo : InfoBase, IMapFrom<ApplicationRole>
{
    public string Name { get; set; } = default!;
}
