using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteIt.Domain.Common;

namespace NoteIt.Infrastructure.Persistence.Configurations;
public class AuditableEntityBaseConfiguration<T> : IEntityTypeConfiguration<T>
    where T : AuditableEntityBase
{
    private readonly string _tableName;

    public AuditableEntityBaseConfiguration(string tableName)
    {
        if (string.IsNullOrWhiteSpace(tableName)) throw new ArgumentException(nameof(tableName));
        _tableName = tableName;
    }

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(_tableName)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Created)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.Modified)
            .HasColumnType("datetime")
            .IsRequired(false);
    }
}
