using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NoteIt.Application.Contracts.Persistence;
using NoteIt.Domain.Common;
using NoteIt.Domain.Entities;
using System.Reflection;

namespace NoteIt.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationRole> Roles { get; set; }
    public DbSet<Note> Notes { get; set; }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
        ) : base(options) { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void UpdateAuditableEntities()
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntityBase>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.Created = DateTime.UtcNow;

            if (entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                entry.Entity.Modified = DateTime.UtcNow;
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
