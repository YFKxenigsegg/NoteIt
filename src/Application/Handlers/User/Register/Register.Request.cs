using NoteIt.Application.Mappings;
using NoteIt.Domain.Entities;

namespace NoteIt.Application.Handlers.User.Register;
public partial class RegisterRequest : IRequest<string>, IMapFrom<ApplicationUser>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}
