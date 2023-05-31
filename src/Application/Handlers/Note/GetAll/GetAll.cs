namespace NoteIt.Application.Handlers.Note;
public class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<NoteInfo>>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public GetAllHandler(
        INoteRepository noteRepository
        , IMapper mapper
        )
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NoteInfo>> Handle(GetAllRequest request, CancellationToken cancellationToken)
    {
        var notes = _noteRepository.GetAll();
        var result = _mapper.Map<IEnumerable<NoteInfo>>(notes);

        return result;
    }
}
