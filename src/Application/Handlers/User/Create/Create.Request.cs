using NoteIt.Application.Mappings;
using NoteIt.Domain.Entities;

namespace NoteIt.Application.Handlers.User;
public partial class CreateRequest : IRequest<string>, IMapFrom<ApplicationUser>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
