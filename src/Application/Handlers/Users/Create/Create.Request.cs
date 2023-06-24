namespace NoteIt.Application.Handlers.Users;
public partial class CreateRequest : IRequest<string>, IMapFrom<User>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string RoleName { get; set; }
}
