using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactRandomJokes.Data.Migrations
{
    public partial class IdChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LitId",
                table: "Jokes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LitId",
                table: "Jokes");
        }
    }
}
