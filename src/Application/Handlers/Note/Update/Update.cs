namespace NoteIt.Application.Handlers.Note;
public class UpdateHandler : IRequestHandler<UpdateRequest, NoteInfo>
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
            ?? throw new NotFoundException(nameof(Domain.Entities.Note), request.Id);

        var noteUpdated = _mapper.Map<Domain.Entities.Note>(request);
        noteUpdated.Created = note.Created;

        _noteRepository.Update(noteUpdated);
        await _noteRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<NoteInfo>(noteUpdated);
    }
}
