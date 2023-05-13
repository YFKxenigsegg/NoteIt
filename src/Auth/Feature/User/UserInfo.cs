using Note.Domain.Entities;
using Note.Infrastructure.Mappings;

namespace Note.Infrastructure.Identity;
public class UserInfo : IMapFrom<UserLogin>
{
    public string Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime Created { get; set; }
    public DateTime LastAccess { get; set; }
}
