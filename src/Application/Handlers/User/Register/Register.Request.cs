﻿using MediatR;
using Note.Application.Mappings;
using Note.Domain.Entities;

namespace Note.Application.Handlers.User.Register;
public partial class RegisterRequest : IRequest<string>, IMapFrom<ApplicationUser>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}