using AutoMapper;
using MediatR;
using Note.Infrastructure.Persistence.Repositories.Interfaces;

namespace Note.Application.Handlers.Note;
public class CreateHandler : IRequestHandler<CreateRequest, string>
{
    private readonly INoteRepository _noteRepository;
    private readonly IMapper _mapper;

    public CreateHandler(
        INoteRepository noteRepository
        , IMapper mapper
        )
    {
        _noteRepository = noteRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        var note = _mapper.Map<Domain.Entities.Note>(request);

        _noteRepository.Add(note);
        await _noteRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return note.Id;
    }
}
