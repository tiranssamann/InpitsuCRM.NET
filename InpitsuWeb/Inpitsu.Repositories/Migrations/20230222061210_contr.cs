using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inpitsu.Repositories.Migrations
{
    public partial class contr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contragents_Contacts_ContactID",
                table: "Contragents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contragents_Email_base_EmailID",
                table: "Contragents");

            migrationBuilder.DropIndex(
                name: "IX_Contragents_ContactID",
                table: "Contragents");

            migrationBuilder.DropIndex(
                name: "IX_Contragents_EmailID",
                table: "Contragents");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Contragents");

            migrationBuilder.DropColumn(
                name: "EmailID",
                table: "Contragents");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Contragents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contragents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Contragents");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contragents");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactID",
                table: "Contragents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmailID",
                table: "Contragents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contragents_ContactID",
                table: "Contragents",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Contragents_EmailID",
                table: "Contragents",
                column: "EmailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contragents_Contacts_ContactID",
                table: "Contragents",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contragents_Email_base_EmailID",
                table: "Contragents",
                column: "EmailID",
                principalTable: "Email_base",
                principalColumn: "ID");
        }
    }
}
