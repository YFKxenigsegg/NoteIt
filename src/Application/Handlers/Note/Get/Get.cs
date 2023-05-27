using AutoMapper;
using MediatR;
using Note.Infrastructure.Exceptions;
using Note.Infrastructure.Persistence.Repositories.Interfaces;

namespace Note.Application.Handlers.Note;
public class GetHandler : IRequestHandler<GetRequest, NoteInfo>
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
            ?? throw new NotFoundException(nameof(Domain.Entities.Note), request.Id);

        var result = _mapper.Map<NoteInfo>(note);
        return result;
    }
}
