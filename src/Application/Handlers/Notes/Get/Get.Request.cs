namespace NoteIt.Application.Handlers.Notes;
public class GetRequest : IRequest<NoteInfo>
{
    public required string Id { get; set; }
}
