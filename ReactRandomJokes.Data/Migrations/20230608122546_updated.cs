using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactRandomJokes.Data.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jokes_Users_UserId",
                table: "Jokes");

            migrationBuilder.DropIndex(
                name: "IX_Jokes_UserId",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Jokes");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikedJokes_UserId",
                table: "UserLikedJokes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedJokes_Jokes_JokeId",
                table: "UserLikedJokes",
                column: "JokeId",
                principalTable: "Jokes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedJokes_Users_UserId",
                table: "UserLikedJokes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedJokes_Jokes_JokeId",
                table: "UserLikedJokes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedJokes_Users_UserId",
                table: "UserLikedJokes");

            migrationBuilder.DropIndex(
                name: "IX_UserLikedJokes_UserId",
                table: "UserLikedJokes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Jokes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jokes_UserId",
                table: "Jokes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jokes_Users_UserId",
                table: "Jokes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
