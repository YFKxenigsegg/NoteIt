namespace NoteIt.Infrastructure.Persistence.Repositories;
public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public RoleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public ApplicationRole Add(ApplicationRole role)
    {
        return _dbContext.Roles.Add(role).Entity;
    }

    public async Task<ApplicationRole?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ApplicationRole?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }

    public IEnumerable<ApplicationRole> GetAll()
    {
        return _dbContext.Roles.AsEnumerable();
    }
}
