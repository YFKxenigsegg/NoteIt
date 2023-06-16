namespace NoteIt.Application.Handlers.Note;
public sealed class DeleteHandler : IRequestHandler<DeleteRequest, Unit>
{
    private readonly INoteRepository _noteRepository;

    public DeleteHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetAsync(request.Id, cancellationToken)
             ?? throw new NotFoundException(nameof(Domain.Entities.Note), request.Id);

        _noteRepository.Delete(note);
        await _noteRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
