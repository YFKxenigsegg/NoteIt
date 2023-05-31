﻿using FluentValidation;

namespace NoteIt.Application.Handlers.User;
public class GetRequestValidator : AbstractValidator<GetRequest>
{
    public GetRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is requered.");
    }
}
