namespace NoteIt.Application.Contracts.Persistence;
public interface IRepository<T>
{
    IUnitOfWork UnitOfWork { get; }
}
