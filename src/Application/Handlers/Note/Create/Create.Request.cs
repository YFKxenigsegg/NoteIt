namespace NoteIt.Application.Handlers.Note;
public class CreateRequest : IRequest<string>, IMapFrom<Domain.Entities.Note>
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
}
