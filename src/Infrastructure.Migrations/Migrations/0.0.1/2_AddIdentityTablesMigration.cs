namespace NoteIt.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 2, "Add identity tables")]
public class AddIdentityTablesMigration : Migration
{
    public override void Up()
    {
        Create.Table("Roles")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Roles_Id")
            .WithColumn("Name").AsString(20).NotNullable()
            .WithColumn("Created").AsDateTime().NotNullable();

        Create.Table("Users")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Users_Id")
            .WithColumn("UserName").AsString(16).NotNullable()
            .WithColumn("NormalizedUserName").AsString(16).NotNullable()
            .WithColumn("Email").AsString(24).NotNullable()
                .Unique("IX_Users_Email")
            .WithColumn("PasswordHash").AsString(96).NotNullable()
            .WithColumn("Created").AsDateTime().NotNullable()
            .WithColumn("Modified").AsDateTime().Nullable()
            .WithColumn("LastAccess").AsDateTime().Nullable()
            .WithColumn("RoleId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_Users_Roles_RoleId", "Roles", "Id");
    }

    public override void Down()
    {
        Delete.Table("Users");
        Delete.Table("Roles");
    }
}
