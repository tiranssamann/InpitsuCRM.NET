using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inpitsu.Repositories.Migrations
{
    public partial class user_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locked",
                table: "AspNetUsers");
        }
    }
}
