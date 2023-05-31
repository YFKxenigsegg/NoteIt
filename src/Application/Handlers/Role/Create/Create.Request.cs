using NoteIt.Application.Mappings;
using NoteIt.Domain.Entities;

namespace NoteIt.Application.Handlers.Role;
public class CreateRequest : IRequest<string>, IMapFrom<ApplicationRole>
{
    public string Name { get; set; } = default!;
}
