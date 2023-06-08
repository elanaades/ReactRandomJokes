using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactRandomJokes.Data.Migrations
{
    public partial class ClassUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Jokes",
                newName: "SetUp");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Jokes",
                newName: "PunchLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SetUp",
                table: "Jokes",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "PunchLine",
                table: "Jokes",
                newName: "Answer");
        }
    }
}
