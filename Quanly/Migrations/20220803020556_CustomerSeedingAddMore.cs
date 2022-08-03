using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class CustomerSeedingAddMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateAdded", "DateOfRecord", "DateUpdated", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2348), new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2345), new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2354), new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2345), new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2349) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateAdded", "DateOfRecord", "DateUpdated", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6862), new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6859), new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 3, 8, 57, 48, 267, DateTimeKind.Local).AddTicks(6863) });
        }
    }
}
