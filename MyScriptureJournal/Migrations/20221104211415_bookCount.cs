using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyScriptureJournal.Migrations
{
    public partial class bookCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CanonName",
                table: "Canon",
                newName: "canonName");

            migrationBuilder.AddColumn<int>(
                name: "bookCount",
                table: "Canon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookCount",
                table: "Canon");

            migrationBuilder.RenameColumn(
                name: "canonName",
                table: "Canon",
                newName: "CanonName");
        }
    }
}
