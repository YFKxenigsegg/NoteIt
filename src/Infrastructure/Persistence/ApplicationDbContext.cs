using Microsoft.EntityFrameworkCore;
using Note.Domain.Entities;
using Note.Infrastructure.Persistence.Interceptors;
using System.Reflection;

namespace Note.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public DbSet<UserLogin> Users { get; set; }
    public DbSet<UserRole> Roles { get; set; }

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
        , AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
        ) : base(options) => _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }
}
