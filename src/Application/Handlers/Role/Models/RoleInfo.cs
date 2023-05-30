using Note.Application.Common;
using Note.Application.Mappings;
using Note.Domain.Entities;

namespace Note.Application.Handlers.Role;
public class RoleInfo : InfoBase, IMapFrom<ApplicationRole>
{
    public string Name { get; set; } = default!;
}
