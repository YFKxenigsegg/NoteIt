namespace NoteIt.Application.Handlers.Notes;
public class DeleteRequest : IRequest<Unit>
{
    public required string Id { get; set; }
}
