﻿using Note.Domain.Entities;

namespace Note.Infrastructure.Persistence.Repositories.Interfaces;
public interface IRoleRepository : IRepository<ApplicationRole>
{
    ApplicationRole Add(ApplicationRole role);
    Task<ApplicationRole?> GetAsync(string id, CancellationToken cancellationToken = default);
    Task<ApplicationRole?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    IEnumerable<ApplicationRole> GetAll();
}