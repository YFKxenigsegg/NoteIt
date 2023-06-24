namespace NoteIt.Application.Contracts.Persistence;
public interface IRoleRepository : IRepository<IdentityRole>
{
    IEnumerable<IdentityRole> GetAll();
}
