namespace NoteIt.Infrastructure.Persistence.Repositories;
public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public RoleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IEnumerable<IdentityRole> GetAll()
    {
        return _dbContext.Roles.AsEnumerable();
    }
}
