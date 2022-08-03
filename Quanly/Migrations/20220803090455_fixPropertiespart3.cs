using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class fixPropertiespart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 16, 4, 55, 236, DateTimeKind.Local).AddTicks(4085), new DateTime(2022, 8, 3, 16, 4, 55, 236, DateTimeKind.Local).AddTicks(4098), new DateTime(2022, 8, 3, 16, 4, 55, 236, DateTimeKind.Local).AddTicks(4096) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 16, 0, 45, 114, DateTimeKind.Local).AddTicks(5818), new DateTime(2022, 8, 3, 16, 0, 45, 114, DateTimeKind.Local).AddTicks(5831), new DateTime(2022, 8, 3, 16, 0, 45, 114, DateTimeKind.Local).AddTicks(5828) });
        }
    }
}
