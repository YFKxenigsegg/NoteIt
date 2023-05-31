using FluentMigrator;

namespace NoteIt.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 2, "Seed initial data")]
public class SeedInitialDataMigration : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Roles").Row(new { Id = Guid.NewGuid().ToString(), Name = "administrator", Created = DateTime.UtcNow });
        Insert.IntoTable("Roles").Row(new { Id = Guid.NewGuid().ToString(), Name = "user", Created = DateTime.UtcNow });

        throw new NotImplementedException();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}
