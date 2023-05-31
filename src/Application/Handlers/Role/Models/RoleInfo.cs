using NoteIt.Application.Common;

namespace NoteIt.Application.Handlers.Role;
public class RoleInfo : InfoBase, IMapFrom<ApplicationRole>
{
    public string Name { get; set; } = default!;
}
