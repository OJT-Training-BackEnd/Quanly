using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class MemberCardAcumulationRelationshipandAcumulateponitsAcumulationrulerelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPerson_Customers_CustomerId",
                table: "ContactPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson");

            migrationBuilder.RenameTable(
                name: "ContactPerson",
                newName: "ContactPersons");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Customers",
                newName: "Points");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPerson_CustomerId",
                table: "ContactPersons",
                newName: "IX_ContactPersons_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccumulatePointsRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplyFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplyTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formula = table.Column<int>(type: "int", nullable: false),
                    Importer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccumulatePointsRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccumulatePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MemberCardsId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Shop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccumulatePointsRulesId = table.Column<int>(type: "int", nullable: false),
                    Importer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccumulatePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccumulatePoints_AccumulatePointsRules_AccumulatePointsRulesId",
                        column: x => x.AccumulatePointsRulesId,
                        principalTable: "AccumulatePointsRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccumulatePoints_MemberCards_MemberCardsId",
                        column: x => x.MemberCardsId,
                        principalTable: "MemberCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccumulatePoints_AccumulatePointsRulesId",
                table: "AccumulatePoints",
                column: "AccumulatePointsRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccumulatePoints_MemberCardsId",
                table: "AccumulatePoints",
                column: "MemberCardsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_Customers_CustomerId",
                table: "ContactPersons",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_Customers_CustomerId",
                table: "ContactPersons");

            migrationBuilder.DropTable(
                name: "AccumulatePoints");

            migrationBuilder.DropTable(
                name: "AccumulatePointsRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons");

            migrationBuilder.RenameTable(
                name: "ContactPersons",
                newName: "ContactPerson");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Customers",
                newName: "Grade");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersons_CustomerId",
                table: "ContactPerson",
                newName: "IX_ContactPerson_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPerson",
                table: "ContactPerson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPerson_Customers_CustomerId",
                table: "ContactPerson",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
