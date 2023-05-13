using MediatR;
using Note.Application.Mappings;
using Note.Domain.Entities;

namespace Note.Application.Users.Users;
public partial class CreateRequest : IRequest<string>, IMapFrom<UserLogin>
{
    public string Email { get; set; } = default!;
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Password { get; set; } = default!;
}
