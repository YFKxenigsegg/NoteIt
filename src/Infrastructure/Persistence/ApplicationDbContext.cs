namespace NoteIt.Infrastructure.Persistence;
public class ApplicationDbContext : IdentityDbContext<User>, IUnitOfWork
{
    //public DbSet<Note> Notes { get; set; }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
        ) : base(options) { }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
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
