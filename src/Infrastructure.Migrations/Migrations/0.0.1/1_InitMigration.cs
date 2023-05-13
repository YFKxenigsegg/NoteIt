using FluentMigrator;
using System.Data;

namespace Note.Infrastructure.Migrations;
[CustomMigration(0, 0, 1, 1, "Init migration")]
public class InitMigration : Migration
{
    public override void Up()
    {
        Delete.Table("__EFMigrationsHistory");

        Create.Table("Roles")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Roles_Id")
            .WithColumn("Name").AsString(16).NotNullable();

        Create.Table("Users")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_Users_Id")
            .WithColumn("Email").AsString(24).NotNullable()
            .WithColumn("PasswordHash").AsString(96).NotNullable()
            .WithColumn("PhoneNumber").AsString(16).NotNullable()
            .WithColumn("FirstName").AsString(16).NotNullable()
            .WithColumn("LastName").AsString(16).NotNullable()
            .WithColumn("Created").AsDateTime().NotNullable()
            .WithColumn("LastAccess").AsDateTime().Nullable()
            .WithColumn("RoleId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_Users_Roles_RoleId", "Roles", "Id").OnDelete(Rule.Cascade)
                .Indexed("IX_Users_RoleId");
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
