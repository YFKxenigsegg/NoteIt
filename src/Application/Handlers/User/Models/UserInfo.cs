using Note.Application.Common;
using Note.Application.Mappings;
using Note.Domain.Entities;

namespace Note.Application.Handlers.User;
public class UserInfo : InfoBase, IMapFrom<ApplicationUser>
{
    public string Email { get; set; } = default!;
    public string RoleId { get; set; } = default!;
}
