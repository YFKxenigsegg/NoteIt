using MediatR;
using NoteIt.Domain.Entities;

namespace NoteIt.Auth.Feature.User;
public class GetRequest : IRequest<ApplicationUser>
{
    public string? Id { get; set; }
    public string? Email { get; set; }
}
