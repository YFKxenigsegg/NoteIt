using MediatR;
using Note.Application.Mappings;
using Note.Domain.Entities;

namespace Note.Application.Handlers.User.Create;
public partial class CreateRequest : IRequest<string>, IMapFrom<ApplicationUser>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
