﻿using Note.Domain.Entities;
using Note.Infrastructure.Mappings;

namespace Note.Infrastructure.Identity;
public class RoleInfo : IMapFrom<ApplicationRole>
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}