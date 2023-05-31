namespace NoteIt.Application.Handlers.Role;
public class GetRequestValidator : AbstractValidator<GetRequest>
{
    public GetRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requered.");
    }
}
