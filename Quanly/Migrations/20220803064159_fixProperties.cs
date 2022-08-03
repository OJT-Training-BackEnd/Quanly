using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class fixProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "MemberCards",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 13, 41, 58, 847, DateTimeKind.Local).AddTicks(7854), new DateTime(2022, 8, 3, 13, 41, 58, 847, DateTimeKind.Local).AddTicks(7871), new DateTime(2022, 8, 3, 13, 41, 58, 847, DateTimeKind.Local).AddTicks(7866) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "MemberCards",
                type: "int",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 13, 37, 2, 955, DateTimeKind.Local).AddTicks(6640), new DateTime(2022, 8, 3, 13, 37, 2, 955, DateTimeKind.Local).AddTicks(6656), new DateTime(2022, 8, 3, 13, 37, 2, 955, DateTimeKind.Local).AddTicks(6653) });
        }
    }
}
