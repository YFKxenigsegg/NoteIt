﻿using NoteIt.Domain.Entities;
using NoteIt.Infrastructure.Mappings;

namespace NoteIt.Infrastructure.Identity;
public class UserInfo : IMapFrom<ApplicationUser>
{
    public string Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime Created { get; set; }
    public DateTime LastAccess { get; set; }
}
