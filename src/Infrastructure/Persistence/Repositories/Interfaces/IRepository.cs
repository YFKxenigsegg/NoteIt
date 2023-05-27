namespace Note.Infrastructure.Persistence.Repositories.Interfaces;
public interface IRepository<T>
{
    IUnitOfWork UnitOfWork { get; }
}
