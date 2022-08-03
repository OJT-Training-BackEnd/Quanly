using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class FixNullablepart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "MemberCards",
                type: "int",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 13, 24, 0, 556, DateTimeKind.Local).AddTicks(6958), new DateTime(2022, 8, 3, 13, 24, 0, 556, DateTimeKind.Local).AddTicks(6973), new DateTime(2022, 8, 3, 13, 24, 0, 556, DateTimeKind.Local).AddTicks(6970) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "MemberCards",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 13, 13, 6, 543, DateTimeKind.Local).AddTicks(4193), new DateTime(2022, 8, 3, 13, 13, 6, 543, DateTimeKind.Local).AddTicks(4209), new DateTime(2022, 8, 3, 13, 13, 6, 543, DateTimeKind.Local).AddTicks(4206) });
        }
    }
}
