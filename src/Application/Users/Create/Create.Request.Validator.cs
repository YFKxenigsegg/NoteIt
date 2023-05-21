using FluentValidation;

namespace Note.Application.Users.Create;
public class CreateRequestValidator : AbstractValidator<CreateRequest>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password length must be at least 8.")
            .MaximumLength(12).WithMessage("Password length must not exceed 12.")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
            .Matches(@"[\!\?\*\@\$\%\#\.]+").WithMessage("Password must contain at least one ('!', '?', '*', '@', '$', '%', '#' '.').");

        RuleFor(x => x.RoleName).NotEmpty().WithMessage("Role is required.");
    }
}
