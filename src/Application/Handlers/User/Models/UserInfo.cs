using NoteIt.Application.Common;

namespace NoteIt.Application.Handlers.User;
public class UserInfo : InfoBase, IMapFrom<ApplicationUser>
{
    public string Email { get; set; } = default!;
    public string RoleId { get; set; } = default!;
}
