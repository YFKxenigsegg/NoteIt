namespace NoteIt.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 1, "Delete EFMigrationsHistory table")]
public class DeleteEFMigrationsHistoryTable : Migration
{
    public override void Up()
    {
        Delete.Table("__EFMigrationsHistory");
    }
    public override void Down()
    {
        Create.Table("__EFMigrationsHistory")
            .WithColumn("MigrationId").AsString(150).NotNullable()
                .PrimaryKey("PK___EFMigrationsHistory")
            .WithColumn("ProductVersion").AsString(32).NotNullable();
    }
}
