using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class CustomerSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Age", "BirthDate", "Code", "CompanyName", "CompanyPhone", "Contact", "CustomerName", "DateAdded", "DateOfRecord", "DateUpdated", "District", "Email", "Fax", "Gender", "IdentityCard", "Importer", "IsActive", "IsMarried", "IssueDate", "Language", "Note", "Phone", "Points", "Position", "Province", "TelePhone", "Type", "Updater" },
                values: new object[] { 1, "District 9, Ho Chi Minh City", 20, new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6862), "KH123456789", "KNS", 1234567891, "An Ngo", "Cong Chinh", new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6859), new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "District 9", "Chinhpro@gmail.com", "+84 (8) 3823 3318", "Male", "343456771234", "", true, false, new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6863), "Vietnamese", "", 1234567891, 0, "Head of KNS", "", 1234567891, "Silver", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
