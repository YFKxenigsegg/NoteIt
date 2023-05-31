using MediatR;
using NoteIt.Infrastructure.Identity;

namespace NoteIt.Auth.Feature.Role;
public class GetRequest : IRequest<RoleInfo>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}
