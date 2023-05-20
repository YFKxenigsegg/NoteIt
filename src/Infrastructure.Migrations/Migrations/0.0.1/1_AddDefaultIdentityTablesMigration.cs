using FluentMigrator;
using System.Data;

namespace Note.Infrastructure.Migrations;
[VersionedMigration(0, 0, 1, 1, "Add default Identity tables")]
public class AddDefaultIdentityTablesMigration : Migration
{
    public override void Up()
    {
        Delete.Table("__EFMigrationsHistory");

        Create.Table("AspNetRoles")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_AspNetRoles_Id")
            .WithColumn("Name").AsString(24).NotNullable();

        Create.Table("AspNetRoleClaims")
            .WithColumn("Id").AsInt32().NotNullable()
                .PrimaryKey("PK_AspNetRoleClaims_Id").Identity()
            .WithColumn("RoleId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_AspNetRoleClaims_AspNetRoles_RoleId", "AspNetRoles", "Id").OnDelete(Rule.Cascade)
                .Indexed("IX_AspNetRoleClaims_RoleId")
            .WithColumn("ClaimType").AsString().Nullable()
            .WithColumn("ClaimValue").AsString().Nullable();

        Create.Table("AspNetUsers")
            .WithColumn("Id").AsFixedLengthString(36).NotNullable()
                .PrimaryKey("PK_AspNetUsers_Id")
            .WithColumn("Email").AsString(24).NotNullable()
                .Unique("IX_AspNetUsers_Email")
            .WithColumn("PasswordHash").AsString(96).NotNullable()
            .WithColumn("Created").AsDateTime().NotNullable()
            .WithColumn("LastAccess").AsDateTime().Nullable()
            .WithColumn("RoleId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_AspNetUsers_AspNetRoles_RoleId", "AspNetRoles", "Id").OnDelete(Rule.Cascade)
                .Indexed("IX_AspNetUsers_RoleId");

        Create.Table("AspNetUserClaims")
            .WithColumn("Id").AsInt32().NotNullable()
                .PrimaryKey("PK_AspNetUserClaims_Id").Identity()
            .WithColumn("UserId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_AspNetUserClaims_AspNetUsers_UserId", "AspNetUsers", "Id").OnDelete(Rule.Cascade)
                .Indexed("IX_AspNetUserClaims_UserId")
            .WithColumn("ClaimType").AsString().Nullable()
            .WithColumn("ClaimValue").AsString().Nullable();

        Create.Table("AspNetUserLogins")
            .WithColumn("LoginProvider").AsString(450).NotNullable()
            .WithColumn("ProviderKey").AsString(450).NotNullable()
            .WithColumn("ProviderDisplayName").AsString().Nullable()
            .WithColumn("UserId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_AspNetUserLogins_AspNetUsers_UserId", "AspNetUsers", "Id").OnDelete(Rule.Cascade)
                .Indexed("IX_AspNetUserLogins_UserId");

        Create.PrimaryKey("PK_AspNetUserLogins_LoginProvider_ProviderKey")
            .OnTable("AspNetUserLogins").Columns("LoginProvider", "ProviderKey");

        Create.Table("AspNetUserRoles")
            .WithColumn("UserId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_AspNetUserRoles_AspNetUsers_UserId", "AspNetUsers", "Id").OnDelete(Rule.Cascade)
            .WithColumn("RoleId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_AspNetUserRoles_AspNetRoles_RoleId", "AspNetRoles", "Id")
                .Indexed("IX_AspNetUserRoles_RoleId");

        Create.PrimaryKey("PK_AspNetUserRoles_UserId_RoleId")
            .OnTable("AspNetUserRoles").Columns("UserId", "RoleId");

        Create.Table("AspNetUserTokens")
            .WithColumn("UserId").AsFixedLengthString(36).NotNullable()
                .ForeignKey("FK_AspNetUserTokens_AspNetUsers_UserId", "AspNetUsers", "Id").OnDelete(Rule.Cascade)
            .WithColumn("LoginProvider").AsString(450).NotNullable()
            .WithColumn("Name").AsString(450).NotNullable()
            .WithColumn("Value").AsString().Nullable();

        Create.PrimaryKey("PK_AspNetUserTokens_UserId_LoginProvider_Name")
            .OnTable("AspNetUserTokens").Columns("UserId", "LoginProvider", "Name");
    }

    public override void Down()
    {
        Delete.Table("AspNetUserTokens");
        Delete.Table("AspNetUserRoles");
        Delete.Table("AspNetUserLogins");
        Delete.Table("AspNetUserClaims");
        Delete.Table("AspNetUsers");
        Delete.Table("AspNetRoleClaims");
        Delete.Table("AspNetRoles");

        Create.Table("__EFMigrationsHistory")
            .WithColumn("MigrationId").AsString(150).NotNullable()
        .PrimaryKey("PK___EFMigrationsHistory")
            .WithColumn("ProductVersion").AsString(32).NotNullable();
    }
}
