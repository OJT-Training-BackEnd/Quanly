using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class FixCustomerSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateAdded", "DateOfRecord", "DateUpdated", "Importer", "IssueDate", "Updater" },
                values: new object[] { new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9687), new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9682), new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9691), new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9683), "Ad", new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9687), "Ad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateAdded", "DateOfRecord", "DateUpdated", "Importer", "IssueDate", "Updater" },
                values: new object[] { new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2348), new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2345), new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2354), new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2345), "", new DateTime(2022, 8, 3, 9, 5, 56, 306, DateTimeKind.Local).AddTicks(2349), "" });
        }
    }
}
