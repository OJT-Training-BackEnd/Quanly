using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class FixingContactPersonProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactPersons_CustomerId",
                table: "ContactPersons");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_CustomerId",
                table: "ContactPersons",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactPersons_CustomerId",
                table: "ContactPersons");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Age", "BirthDate", "Code", "CompanyName", "CompanyPhone", "Contact", "CustomerName", "DateAdded", "DateOfRecord", "District", "Email", "Fax", "Gender", "IdentityCard", "Importer", "IsActive", "IsMarried", "IssueDate", "Language", "Note", "Phone", "Points", "Position", "Province", "TelePhone", "Type" },
                values: new object[] { 1, "District 9, Ho Chi Minh City", "20", new DateTime(2022, 8, 5, 17, 11, 54, 850, DateTimeKind.Local).AddTicks(672), "KH123456789", "KNS", "01234567891", "An Ngo", "Cong Chinh", null, new DateTime(2022, 8, 5, 17, 11, 54, 850, DateTimeKind.Local).AddTicks(688), "District 9", "Chinhpro@gmail.com", "+84 (8) 3823 3318", "Male", "343456771234", "Ad", true, false, new DateTime(2022, 8, 5, 17, 11, 54, 850, DateTimeKind.Local).AddTicks(685), "Vietnamese", "", "0123456789", null, "Head of KNS", "", "01234567891", "Silver" });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPersons_CustomerId",
                table: "ContactPersons",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");
        }
    }
}
