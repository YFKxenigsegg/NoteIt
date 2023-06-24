namespace NoteIt.Application.Handlers.Notes;
public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    public UpdateRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requered.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is requered.");
        RuleFor(x => x.Url).NotEmpty().WithMessage("Url is requered.");
    }
}
