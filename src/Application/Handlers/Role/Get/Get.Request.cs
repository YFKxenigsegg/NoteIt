using MediatR;

namespace Note.Application.Handlers.Role;
public class GetRequest : IRequest<RoleInfo>
{
    public string Id { get; set; } = default!;
}
