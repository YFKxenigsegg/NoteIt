using NoteIt.Application.Handlers.Account;
using NoteIt.Application.Handlers.User;

namespace NoteIt.Application.Handlers.User.Register;
public class RegisterHandler : IRequestHandler<RegisterRequest, Unit>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RegisterHandler(
        IMediator mediator
        , IMapper mapper
        )
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var createRequest = _mapper.Map<CreateRequest>(request);
        await _mediator.Send(createRequest, cancellationToken);
        return Unit.Value;
    }
}
