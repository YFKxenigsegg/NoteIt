namespace NoteIt.Application.Handlers.Notes;
public class DeleteRequestValidator : AbstractValidator<DeleteRequest>
{
	public DeleteRequestValidator()
	{
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requered.");
    }
}
