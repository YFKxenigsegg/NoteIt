namespace NoteIt.Application.Handlers.Users;
public class UpdateRequest : IRequest<UserInfo>
{
    public required string Id { get; set; }
    public required string RoleName { get; set; }
}
