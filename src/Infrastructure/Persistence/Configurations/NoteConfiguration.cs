using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteIt.Domain.Entities;

namespace NoteIt.Infrastructure.Persistence.Configurations;
public class NoteConfiguration : AuditableEntityBaseConfiguration<Note>
{
    public NoteConfiguration() : base("Notes") { }

    public override void Configure(EntityTypeBuilder<Note> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(x => x.Url)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(128);
    }
}
