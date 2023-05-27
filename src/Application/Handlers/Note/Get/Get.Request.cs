using MediatR;

namespace Note.Application.Handlers.Note;
public class GetRequest : IRequest<NoteInfo>
{
    public string Id { get; set; } = default!;
}
