namespace NoteIt.Application.Contracts.Persistence;
public interface IUserRepository : IRepository<User>
{
    void Update(User user);
    User Add(User user);
    Task<User?> GetAsync(string id, CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    IEnumerable<User> GetAll();
}
