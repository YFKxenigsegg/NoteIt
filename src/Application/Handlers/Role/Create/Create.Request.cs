using NoteIt.Application.Mappings;

namespace NoteIt.Application.Handlers.Role;
public class CreateRequest : IRequest<string>, IMapFrom<ApplicationRole>
{
    public string Name { get; set; } = default!;
}
