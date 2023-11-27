using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inpitsu.Repositories.Migrations
{
    public partial class contrDelet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contragents_Address_AddressID",
                table: "Contragents");

            migrationBuilder.DropIndex(
                name: "IX_Contragents_AddressID",
                table: "Contragents");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Contragents");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contragents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contragents");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "Contragents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contragents_AddressID",
                table: "Contragents",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contragents_Address_AddressID",
                table: "Contragents",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID");
        }
    }
}
