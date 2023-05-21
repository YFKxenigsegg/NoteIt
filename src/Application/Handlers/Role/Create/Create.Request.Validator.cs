using FluentValidation;

namespace Note.Application.Handlers.Role.Create;
public class CreateRequestValidator : AbstractValidator<CreateRequest>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
