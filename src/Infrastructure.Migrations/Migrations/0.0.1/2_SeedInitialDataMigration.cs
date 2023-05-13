using FluentMigrator;

namespace Note.Infrastructure.Migrations;
[CustomMigration(0, 0, 1, 2, "Seed initial data")]
public class SeedInitialDataMigration : Migration
{
    public override void Up()
    {
        var roleId = Guid.NewGuid();

        Insert.IntoTable("Roles").Row(new { Id = roleId, Name = "administrator" });
        Insert.IntoTable("Users").Row(new
        {
            Id = Guid.NewGuid(),
            Email = "admin@gmail.com",
            PasswordHash = "$2y$12$9Rn3ocLwa/yW3.0j8FaPCOH5peTKsLHDk4hPs3bccv4PHiMGHKN42",
            PhoneNumber = "+166666666",
            FirstName = "Fadmin",
            LastName = "Sadmin",
            Created = DateTime.UtcNow,
            RoleId = roleId
        });
    }

    public override void Down()
    {
        Delete.FromTable("Roles").Row(new { Name = "administrator" });
    }
}
