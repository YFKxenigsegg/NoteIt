namespace NoteIt.Infrastructure.Persistence.Repositories;
public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public NoteRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Update(Domain.Entities.Note note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
    }

    public void Delete(Domain.Entities.Note note)
    {
        _dbContext.Entry(note).State = EntityState.Deleted;
    }

    public Domain.Entities.Note Add(Domain.Entities.Note note)
    {
        return _dbContext.Notes.Add(note).Entity;
    }

    public async Task<Domain.Entities.Note?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Notes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public IEnumerable<Domain.Entities.Note> GetAll()
    {
        return _dbContext.Notes.AsEnumerable();
    }
}
