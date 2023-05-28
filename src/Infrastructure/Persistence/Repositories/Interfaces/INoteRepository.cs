namespace Note.Infrastructure.Persistence.Repositories.Interfaces;
public interface INoteRepository : IRepository<Domain.Entities.Note>
{
    void Update(Domain.Entities.Note note);
    void Delete(Domain.Entities.Note note);
    Domain.Entities.Note Add(Domain.Entities.Note note);
    Task<Domain.Entities.Note?> GetAsync(string id, CancellationToken cancellationToken = default);
    IEnumerable<Domain.Entities.Note> GetAll();
}
