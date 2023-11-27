using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inpitsu.Repositories.Migrations
{
    public partial class drugItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReleaseDrugItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfDrug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Counts = table.Column<int>(type: "int", nullable: true),
                    FormCreations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComingPrice = table.Column<double>(type: "float", nullable: true),
                    ComingProcent = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Procent = table.Column<double>(type: "float", nullable: false),
                    DateOfExplotation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComingDrugID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseDrugItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseDrugItems_ComingDrug_ComingDrugID",
                        column: x => x.ComingDrugID,
                        principalTable: "ComingDrug",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDrugItems_ComingDrugID",
                table: "ReleaseDrugItems",
                column: "ComingDrugID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReleaseDrugItems");
        }
    }
}
