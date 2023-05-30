using MediatR;

namespace Note.Application.Handlers.User;
public class UpdateRequest : IRequest<UserInfo>
{
    public string Id { get; set; } = default!;
    public string RoleId { get; set; } = default!;
}
