using Note.Application.Common;
using Note.Application.Mappings;

namespace Note.Application.Handlers.Note;
public class NoteInfo : InfoBase, IMapFrom<Domain.Entities.Note>
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}
