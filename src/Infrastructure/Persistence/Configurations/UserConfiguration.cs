using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Note.Domain.Entities;

namespace Note.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasKey(x => x.Id);

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

        builder.Property(x => x.PhoneNumber)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(x => x.FirstName)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.LastName)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.Created)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.LastAccess)
            .HasColumnType("datetime")
            .IsRequired(false);

        builder.Property(x => x.RoleId)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .IsRequired()
            .HasForeignKey(x => x.RoleId);

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
    }
}
