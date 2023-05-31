using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteIt.Domain.Entities;

namespace NoteIt.Infrastructure.Persistence.Configurations;
public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("Roles")
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(12);

        builder.Property(x => x.Created)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Ignore(x => x.ConcurrencyStamp);
        builder.Ignore(x => x.NormalizedName);
    }
}
