namespace NoteIt.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users")
            .HasKey(x => x.Id);

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
        builder.Ignore(x => x.PhoneNumberConfirmed);
        builder.Ignore(x => x.SecurityStamp);
        builder.Ignore(x => x.TwoFactorEnabled);
        builder.Ignore(x => x.PhoneNumber);
    }
}
