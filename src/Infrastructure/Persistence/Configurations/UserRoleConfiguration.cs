using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Note.Domain.Entities;

namespace Note.Infrastructure.Persistence.Configurations;
public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnType("nvarchar")
            .IsRequired()
            .HasMaxLength(24);

        builder.HasMany(x => x.Users)
            .WithOne(x => x.Role)
            .IsRequired()
            .HasForeignKey(x => x.RoleId);

        builder.Ignore(x => x.ConcurrencyStamp);
        builder.Ignore(x => x.NormalizedName);
    }
}
