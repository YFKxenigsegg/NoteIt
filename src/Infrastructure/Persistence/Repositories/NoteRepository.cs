namespace NoteIt.Infrastructure.Persistence.Repositories;
public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public NoteRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Update(Note note)
    {
        _dbContext.Entry(note).State = EntityState.Modified;
    }

    public void Delete(Note note)
    {
        _dbContext.Entry(note).State = EntityState.Deleted;
    }

    public Note Add(Note note)
    {
        //return _dbContext.Notes.Add(note).Entity;
        throw new NotImplementedException();
    }

    public async Task<Note?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        //return await _dbContext.Notes
        //    .AsNoTracking()
        //    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        throw new NotImplementedException();
    }

    public IEnumerable<Note> GetAll()
    {
        //return _dbContext.Notes.AsEnumerable();
        throw new NotImplementedException();
    }
}
