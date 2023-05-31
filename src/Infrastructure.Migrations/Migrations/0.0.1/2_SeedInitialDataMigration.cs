using FluentMigrator;

namespace NoteIt.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 2, "Seed initial data")]
public class SeedInitialDataMigration : Migration
{
    public override void Up()
    {
        Create.Table("Notes")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Notes_Id")
            .WithColumn("Name").AsString(24).NotNullable()
            .WithColumn("Url").AsString(24).NotNullable()
            .WithColumn("Created").AsDateTime().NotNullable()
            .WithColumn("Modified").AsDateTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("Notes");
    }
}
