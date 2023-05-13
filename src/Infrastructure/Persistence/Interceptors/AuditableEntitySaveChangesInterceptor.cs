using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Note.Domain.Common;
using Note.Infrastructure.Persistence.Helpers.Interfaces;

namespace Note.Infrastructure.Persistence.Interceptors;
public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IDateTimeHelper _dateTimeHelper;

    public AuditableEntitySaveChangesInterceptor(
        IDateTimeHelper dateTimeHelper
        ) => _dateTimeHelper = dateTimeHelper;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<AuditableEntityBase>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.Created = _dateTimeHelper.UtcNow;

            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                entry.Entity.Modified = _dateTimeHelper.UtcNow;
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(x => x.TargetEntry != null
            && x.TargetEntry.Metadata.IsOwned()
            && (x.TargetEntry.State == EntityState.Added || x.TargetEntry.State == EntityState.Modified));
}
