using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inpitsu.Repositories.Migrations
{
    public partial class new_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Contragents_ContragentId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contragents_Contact_ContactID",
                table: "Contragents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contragents_Email_EmailID",
                table: "Contragents");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Email_EmailID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Contact_ContactID",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Email",
                table: "Email");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contract",
                table: "Contract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Email",
                newName: "Email_base");

            migrationBuilder.RenameTable(
                name: "Contract",
                newName: "Contracts");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_ContragentId",
                table: "Contracts",
                newName: "IX_Contracts_ContragentId");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationForId",
                table: "Attaches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Email_base",
                table: "Email_base",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealPan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateActivate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeCard = table.Column<int>(type: "int", nullable: true),
                    TypePaySystem = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCards_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComingDrug",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameOfComing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateOfComing = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComingDrug", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComingDrug_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISOCode = table.Column<int>(type: "int", nullable: true),
                    ISOCodeAlpha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDelivery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryObjects_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_BankCards_BankCardId",
                        column: x => x.BankCardId,
                        principalTable: "BankCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
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
                    table.PrimaryKey("PK_Drug", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drug_ComingDrug_ComingDrugID",
                        column: x => x.ComingDrugID,
                        principalTable: "ComingDrug",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAccept = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SumAccept = table.Column<long>(type: "bigint", nullable: true),
                    SumNeed = table.Column<long>(type: "bigint", nullable: true),
                    StatusApplication = table.Column<int>(type: "int", nullable: true),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrasePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCount = table.Column<int>(type: "int", nullable: true),
                    EmployeeCountWomen = table.Column<int>(type: "int", nullable: true),
                    WorkCreate = table.Column<int>(type: "int", nullable: true),
                    PurposeOfFunding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFor_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationFor_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attaches_ApplicationForId",
                table: "Attaches",
                column: "ApplicationForId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankCardId",
                table: "Accounts",
                column: "BankCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ContragentId",
                table: "Accounts",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFor_ContragentId",
                table: "ApplicationFor",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFor_CurrencyId",
                table: "ApplicationFor",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_ContragentId",
                table: "BankCards",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComingDrug_ContragentId",
                table: "ComingDrug",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryObjects_ContragentId",
                table: "DeliveryObjects",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_ComingDrugID",
                table: "Drug",
                column: "ComingDrugID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attaches_ApplicationFor_ApplicationForId",
                table: "Attaches",
                column: "ApplicationForId",
                principalTable: "ApplicationFor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Contragents_ContragentId",
                table: "Contracts",
                column: "ContragentId",
                principalTable: "Contragents",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Email_base_EmailID",
                table: "Emails",
                column: "EmailID",
                principalTable: "Email_base",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Contacts_ContactID",
                table: "Phones",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attaches_ApplicationFor_ApplicationForId",
                table: "Attaches");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Contragents_ContragentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contragents_Contacts_ContactID",
                table: "Contragents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contragents_Email_base_EmailID",
                table: "Contragents");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Email_base_EmailID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Contacts_ContactID",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ApplicationFor");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "DeliveryObjects");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "ComingDrug");

            migrationBuilder.DropIndex(
                name: "IX_Attaches_ApplicationForId",
                table: "Attaches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Email_base",
                table: "Email_base");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ApplicationForId",
                table: "Attaches");

            migrationBuilder.RenameTable(
                name: "Email_base",
                newName: "Email");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Contract");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ContragentId",
                table: "Contract",
                newName: "IX_Contract_ContragentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Email",
                table: "Email",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contract",
                table: "Contract",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Contragents_ContragentId",
                table: "Contract",
                column: "ContragentId",
                principalTable: "Contragents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contragents_Contact_ContactID",
                table: "Contragents",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contragents_Email_EmailID",
                table: "Contragents",
                column: "EmailID",
                principalTable: "Email",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Email_EmailID",
                table: "Emails",
                column: "EmailID",
                principalTable: "Email",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Contact_ContactID",
                table: "Phones",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ID");
        }
    }
}
