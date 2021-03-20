using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareAndCare.Migrations
{
    public partial class wtf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Friends_FriendId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_FriendId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Friends");

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_FriendId",
                table: "Files",
                column: "FriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Friends_FriendId",
                table: "Files",
                column: "FriendId",
                principalTable: "Friends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
