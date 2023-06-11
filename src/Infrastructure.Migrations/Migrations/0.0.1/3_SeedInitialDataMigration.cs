namespace NoteIt.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 3, "Seed initial data")]
public class SeedInitialDataMigration : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Roles").Row(new { Id = Guid.NewGuid().ToString(), Name = "administrator", Created = DateTime.UtcNow });
        Insert.IntoTable("Roles").Row(new { Id = Guid.NewGuid().ToString(), Name = "user", Created = DateTime.UtcNow });
    }

    public override void Down()
    {
        Delete.FromTable("Roles").Row(new { Name = "administrator" });
        Delete.FromTable("Roles").Row(new { Name = "user" });
    }
}
