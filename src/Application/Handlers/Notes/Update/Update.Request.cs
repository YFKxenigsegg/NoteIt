namespace NoteIt.Application.Handlers.Notes;
public class UpdateRequest : IRequest<NoteInfo>, IMapFrom<Note>
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }
}
