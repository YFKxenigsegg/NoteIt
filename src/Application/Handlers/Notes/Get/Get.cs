namespace NoteIt.Application.Handlers.Notes;
public sealed class GetHandler : IRequestHandler<GetRequest, NoteInfo>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public GetHandler(
        INoteRepository noteRepository
        , IMapper mapper
        )
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }

    public async Task<NoteInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var note = await _noteRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Note), request.Id);

        var result = _mapper.Map<NoteInfo>(note);
        return result;
    }
}
