using NoteIt.Application.Common;
using NoteIt.Application.Mappings;
using NoteIt.Domain.Entities;

namespace NoteIt.Application.Handlers.User;
public class UserInfo : InfoBase, IMapFrom<ApplicationUser>
{
    public string Email { get; set; } = default!;
    public string RoleId { get; set; } = default!;
}
