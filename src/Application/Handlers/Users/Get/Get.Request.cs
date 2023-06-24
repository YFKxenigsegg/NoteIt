namespace NoteIt.Application.Handlers.Users;
public class GetRequest : IRequest<UserInfo>
{
    public required string Id { get; set; } = default!;
}
