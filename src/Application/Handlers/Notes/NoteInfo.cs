namespace NoteIt.Application.Handlers.Notes;
public class NoteInfo : InfoBase, IMapFrom<Note>
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}
