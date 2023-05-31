namespace NoteIt.Application.Handlers.Note;
public class CreateRequestValidator : AbstractValidator<CreateRequest>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is requered.")
            .MaximumLength(16).WithMessage("Name should be equal or less than 12 symbols");

        RuleFor(x => x.Url).NotEmpty().WithMessage("Url is requered.")
            .MaximumLength(128).WithMessage("Url should be equal or less than 12 symbols");
    }
}
