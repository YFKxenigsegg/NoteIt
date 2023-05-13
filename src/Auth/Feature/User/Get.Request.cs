using MediatR;
using Note.Infrastructure.Identity;

namespace Note.Auth.Feature.User;
public class GetRequest : IRequest<UserInfo>
{
    public string? Id { get; set; }
    public string? Email { get; set; }
}
