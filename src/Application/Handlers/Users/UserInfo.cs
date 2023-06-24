namespace NoteIt.Application.Handlers.Users;
public class UserInfo : InfoBase, IMapFrom<User>
{
    public required string Email { get; set; }
    public required string RoleName { get; set; }
}
