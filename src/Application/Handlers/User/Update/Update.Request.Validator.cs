using FluentValidation;

namespace Note.Application.Handlers.User;
public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    public UpdateRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requered.");

        RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role is requered.");
    }
}
