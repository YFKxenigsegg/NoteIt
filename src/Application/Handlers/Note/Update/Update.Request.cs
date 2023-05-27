using MediatR;
using Note.Application.Mappings;

namespace Note.Application.Handlers.Note;
public class UpdateRequest : IRequest<NoteInfo>, IMapFrom<Domain.Entities.Note>
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}
