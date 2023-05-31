namespace NoteIt.Application.Handlers.User;
public class UpdateRequest : IRequest<UserInfo>
{
    public string Id { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
