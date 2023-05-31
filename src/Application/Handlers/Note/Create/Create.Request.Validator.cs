namespace NoteIt.Application.Handlers.Note;
public class CreateRequestValidator : AbstractValidator<CreateRequest>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is requered.");

        RuleFor(x => x.Url).NotEmpty().WithMessage("Url is requered.");
    }
}
