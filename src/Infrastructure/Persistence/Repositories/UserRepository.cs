namespace NoteIt.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public ApplicationUser Add(ApplicationUser user)
    {
        return _dbContext.Users.Add(user).Entity;
    }

    public void Update(ApplicationUser user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
    }

    public async Task<ApplicationUser?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ApplicationUser?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public IEnumerable<ApplicationUser> GetAll()
    {
        return _dbContext.Users.AsEnumerable();
    }
}
