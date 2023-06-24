namespace NoteIt.Application.Handlers.Notes;
public sealed class UpdateHandler : IRequestHandler<UpdateRequest, NoteInfo>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public UpdateHandler(
        INoteRepository noteRepository
        , IMapper mapper
        )
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }

    public async Task<NoteInfo> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Note), request.Id);

        var noteUpdated = _mapper.Map<Note>(request);
        noteUpdated.Created = note.Created;

        _noteRepository.Update(noteUpdated);
        await _noteRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<NoteInfo>(noteUpdated);
    }
}
