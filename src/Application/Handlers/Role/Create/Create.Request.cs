using Note.Application.Mappings;
using Note.Domain.Entities;

namespace Note.Application.Handlers.Role;
public class CreateRequest : IRequest<string>, IMapFrom<ApplicationRole>
{
    public string Name { get; set; } = default!;
}
