using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteIt.Domain.Entities;

namespace NoteIt.Infrastructure.Persistence.Configurations;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users")
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Email)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(24);

        builder.Property(x => x.PasswordHash)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(96);

        builder.Property(x => x.Created)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.Modified)
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Property(x => x.LastAccess)
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Ignore(x => x.AccessFailedCount);
        builder.Ignore(x => x.EmailConfirmed);
        builder.Ignore(x => x.ConcurrencyStamp);
        builder.Ignore(x => x.LockoutEnabled);
        builder.Ignore(x => x.LockoutEnd);
        builder.Ignore(x => x.NormalizedEmail);
        builder.Ignore(x => x.NormalizedUserName);
        builder.Ignore(x => x.PhoneNumberConfirmed);
        builder.Ignore(x => x.SecurityStamp);
        builder.Ignore(x => x.TwoFactorEnabled);
        builder.Ignore(x => x.UserName);
        builder.Ignore(x => x.PhoneNumber);
    }
}
