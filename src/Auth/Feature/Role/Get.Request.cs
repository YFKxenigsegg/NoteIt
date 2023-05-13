using MediatR;
using Note.Infrastructure.Identity;

namespace Note.Auth.Feature.Role;
public class GetRequest : IRequest<RoleInfo>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}
