using MediatR;
using Note.Application.Mappings;
using Note.Domain.Entities;

namespace Note.Application.Role;
public class CreateRequest : IRequest<string>, IMapFrom<UserRole>
{
    public string Name { get; set; } = default!;
}
