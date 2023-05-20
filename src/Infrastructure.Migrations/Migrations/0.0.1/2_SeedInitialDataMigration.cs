using FluentMigrator;

namespace Note.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 2, "Seed initial data")]
public class SeedInitialDataMigration : Migration
{
    public override void Up()
    {
        var roleId = Guid.NewGuid();
        Insert.IntoTable("AspNetRoles").Row(new { Id = roleId, Name = "administrator" });
        Insert.IntoTable("AspNetRoles").Row(new { Id = Guid.NewGuid(), Name = "user" });
        Insert.IntoTable("AspNetRoles").Row(new { Id = Guid.NewGuid(), Name = "customer" });
        Insert.IntoTable("AspNetRoles").Row(new { Id = Guid.NewGuid(), Name = "contractor" });

        var userId = Guid.NewGuid();
        Insert.IntoTable("AspNetUsers").Row(new
        {
            Id = userId,
            Email = "admin@gmail.com",
            PasswordHash = "$2y$12$9Rn3ocLwa/yW3.0j8FaPCOH5peTKsLHDk4hPs3bccv4PHiMGHKN42",
            Created = DateTime.UtcNow,
            RoleId = roleId
        });

        Insert.IntoTable("AspNetUserRoles").Row(new { UserId = userId, RoleId = roleId });
    }

    public override void Down()
    {
        Delete.FromTable("AspNetRoles").Row(new { Name = "administrator" });
        Delete.FromTable("AspNetRoles").Row(new { Name = "user" });
        Delete.FromTable("AspNetRoles").Row(new { Name = "customer" });
        Delete.FromTable("AspNetRoles").Row(new { Name = "contractor" });
    }
}
