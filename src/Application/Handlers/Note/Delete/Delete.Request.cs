using MediatR;

namespace Note.Application.Handlers.Note;
public class DeleteRequest : IRequest<Unit>
{
    public string Id { get; set; } = default!;
}
