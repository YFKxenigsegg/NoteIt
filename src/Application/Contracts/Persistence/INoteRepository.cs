namespace NoteIt.Application.Contracts.Persistence;
public interface INoteRepository : IRepository<Note>
{
    void Update(Note note);
    void Delete(Note note);
    Note Add(Note note);
    Task<Note?> GetAsync(string id, CancellationToken cancellationToken = default);
    IEnumerable<Note> GetAll();
}
