namespace NoteIt.Application.Handlers.Notes;
public class CreateRequest : IRequest<string>, IMapFrom<Note>
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}
