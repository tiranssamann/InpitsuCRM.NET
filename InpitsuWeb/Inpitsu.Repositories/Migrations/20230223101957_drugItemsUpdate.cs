using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inpitsu.Repositories.Migrations
{
    public partial class drugItemsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReleaseDrugId",
                table: "ReleaseDrugItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDrugItems_ReleaseDrugId",
                table: "ReleaseDrugItems",
                column: "ReleaseDrugId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseDrugItems_ReleaseDrugs_ReleaseDrugId",
                table: "ReleaseDrugItems",
                column: "ReleaseDrugId",
                principalTable: "ReleaseDrugs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseDrugItems_ReleaseDrugs_ReleaseDrugId",
                table: "ReleaseDrugItems");

            migrationBuilder.DropIndex(
                name: "IX_ReleaseDrugItems_ReleaseDrugId",
                table: "ReleaseDrugItems");

            migrationBuilder.DropColumn(
                name: "ReleaseDrugId",
                table: "ReleaseDrugItems");
        }
    }
}
