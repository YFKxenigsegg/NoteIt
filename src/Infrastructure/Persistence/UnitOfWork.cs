//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using Note.Domain.Common;

//namespace Note.Infrastructure.Persistence;
//public sealed class UnitOfWork : IUnitOfWork
//{
//    private readonly ApplicationDbContext _dbContext;

//    public UnitOfWork(ApplicationDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//    {
//        UpdateAuditableEntities();
//        return _dbContext.SaveChangesAsync(cancellationToken);
//    }

//    private void UpdateAuditableEntities()
//    {
//        foreach (var entry in _dbContext.ChangeTracker.Entries<AuditableEntityBase>())
//        {
//            if (entry.State == EntityState.Added)
//                entry.Entity.Created = DateTime.UtcNow;

//            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
//                entry.Entity.Modified = DateTime.UtcNow;
//        }
//    }

//    // Convert domain events to out box messages
//}

//public static class Extensions
//{
//    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
//        entry.References.Any(x => x.TargetEntry != null
//            && x.TargetEntry.Metadata.IsOwned()
//            && (x.TargetEntry.State == EntityState.Added || x.TargetEntry.State == EntityState.Modified));
//}