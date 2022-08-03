using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class FixNullablepart5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 13, 37, 2, 955, DateTimeKind.Local).AddTicks(6640), new DateTime(2022, 8, 3, 13, 37, 2, 955, DateTimeKind.Local).AddTicks(6656), new DateTime(2022, 8, 3, 13, 37, 2, 955, DateTimeKind.Local).AddTicks(6653) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(3972), new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(4081), new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(4078) });
        }
    }
}
