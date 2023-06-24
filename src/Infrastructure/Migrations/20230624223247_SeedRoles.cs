using Microsoft.EntityFrameworkCore.Migrations;
using NoteIt.Domain.Entities;

#nullable disable

namespace NoteIt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { Guid.NewGuid().ToString(), "administrator" },
                    { Guid.NewGuid().ToString(), "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM AspNetRoles
                                   WHERE Name = 'administrator'");

            migrationBuilder.Sql(@"DELETE FROM AspNetRoles
                                   WHERE Name = 'user'");
        }
    }
}
