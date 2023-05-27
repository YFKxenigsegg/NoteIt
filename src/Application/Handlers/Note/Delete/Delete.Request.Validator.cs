using FluentValidation;

namespace Note.Application.Handlers.Note;
public class DeleteRequestValidator : AbstractValidator<DeleteRequest>
{
	public DeleteRequestValidator()
	{
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requered.");
    }
}
