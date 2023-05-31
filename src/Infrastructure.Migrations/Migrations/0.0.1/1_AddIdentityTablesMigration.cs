using FluentMigrator;

namespace NoteIt.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 1, "Add identity tables")]
public class AddIdentityTablesMigration : Migration
{
    public override void Up()
    {
        Delete.Table("__EFMigrationsHistory");

        Create.Table("Roles")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Roles_Id")
            .WithColumn("Name").AsString(20).NotNullable()
            .WithColumn("Created").AsDateTime().NotNullable();

        Create.Table("Users")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Users_Id")
            .WithColumn("Email").AsString(24).NotNullable()
                .Unique("IX_Users_Email")
            .WithColumn("PasswordHash").AsString(36).NotNullable()
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

        Create.Table("__EFMigrationsHistory")
            .WithColumn("MigrationId").AsString(150).NotNullable()
        .PrimaryKey("PK___EFMigrationsHistory")
            .WithColumn("ProductVersion").AsString(32).NotNullable();
    }
}
