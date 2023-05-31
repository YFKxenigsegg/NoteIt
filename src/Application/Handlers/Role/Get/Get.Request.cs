namespace NoteIt.Application.Handlers.Role;
public class GetRequest : IRequest<RoleInfo>
{
    public string Id { get; set; } = default!;
}
