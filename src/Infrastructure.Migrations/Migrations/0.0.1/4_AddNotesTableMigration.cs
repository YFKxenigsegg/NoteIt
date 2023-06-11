namespace NoteIt.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 4, "Add Notes table")]
public class AddNotesTableMigration : Migration
{
    public override void Up()
    {
        Create.Table("Notes")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Notes_Id")
            .WithColumn("Name").AsString(16).NotNullable()
            .WithColumn("Url").AsString(128).NotNullable()
            .WithColumn("Created").AsDateTime().NotNullable()
            .WithColumn("Modified").AsDateTime().Nullable();
    }

    public override void Down()
    {
        Delete.Table("Notes");
    }
}
