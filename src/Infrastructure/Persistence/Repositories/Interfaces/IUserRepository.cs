using Note.Domain.Entities;

namespace Note.Infrastructure.Persistence.Repositories.Interfaces;
public interface IUserRepository : IRepository<ApplicationUser>
{
    void Update(ApplicationUser user);
    ApplicationUser Add(ApplicationUser user);
    Task<ApplicationUser?> GetAsync(string id, CancellationToken cancellationToken = default);
    Task<ApplicationUser?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    IEnumerable<ApplicationUser> GetAll();
}
