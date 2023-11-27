using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inpitsu.Repositories.Migrations
{
    public partial class dr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReleaseDrugId",
                table: "Drug",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReleaseDrugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseDrugs_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drug_ReleaseDrugId",
                table: "Drug",
                column: "ReleaseDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDrugs_ContragentId",
                table: "ReleaseDrugs",
                column: "ContragentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drug_ReleaseDrugs_ReleaseDrugId",
                table: "Drug",
                column: "ReleaseDrugId",
                principalTable: "ReleaseDrugs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drug_ReleaseDrugs_ReleaseDrugId",
                table: "Drug");

            migrationBuilder.DropTable(
                name: "ReleaseDrugs");

            migrationBuilder.DropIndex(
                name: "IX_Drug_ReleaseDrugId",
                table: "Drug");

            migrationBuilder.DropColumn(
                name: "ReleaseDrugId",
                table: "Drug");
        }
    }
}
