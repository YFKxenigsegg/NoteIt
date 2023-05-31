namespace NoteIt.Application.Handlers.Role;
public class CreateRequestValidator : AbstractValidator<CreateRequest>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
            .MaximumLength(12).WithMessage("Name should be equal or less than 12 letters");
    }
}
