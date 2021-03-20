using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareAndCare.Migrations
{
    public partial class friendid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "friendId",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "friendId",
                table: "Friends");
        }
    }
}
