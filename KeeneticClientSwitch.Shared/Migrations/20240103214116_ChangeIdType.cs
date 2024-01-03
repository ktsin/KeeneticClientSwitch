using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeeneticClientSwitch.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LastLogins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Host = table.Column<string>(type: "TEXT", nullable: false),
                    RecordedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastLogins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastLogins_RecordedAt",
                table: "LastLogins",
                column: "RecordedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastLogins");
        }
    }
}
