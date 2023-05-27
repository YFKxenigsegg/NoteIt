using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Note.Infrastructure.Persistence.Configurations;
public class NoteConfiguration : IEntityTypeConfiguration<Domain.Entities.Note>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Note> builder)
    {
        builder.ToTable("Notes");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name) //
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(24);

        builder.Property(x => x.Url) //
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(24);

        builder.Property(x => x.Created)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.Modified)
            .HasColumnType("datetime")
            .IsRequired(false);
    }
}
