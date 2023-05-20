using MediatR;
using Note.Domain.Entities;

namespace Note.Auth.Feature.User;
public class GetRequest : IRequest<ApplicationUser>
{
    public string? Id { get; set; }
    public string? Email { get; set; }
}
