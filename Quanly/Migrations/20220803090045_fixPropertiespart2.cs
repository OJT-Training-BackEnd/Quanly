using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class fixPropertiespart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MemberCards",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "ContactPersons",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Formula",
                table: "AccumulatePointsRules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Points",
                table: "AccumulatePoints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Money",
                table: "AccumulatePoints",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 16, 0, 45, 114, DateTimeKind.Local).AddTicks(5818), new DateTime(2022, 8, 3, 16, 0, 45, 114, DateTimeKind.Local).AddTicks(5831), new DateTime(2022, 8, 3, 16, 0, 45, 114, DateTimeKind.Local).AddTicks(5828) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MemberCards");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "ContactPersons",
                type: "int",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Formula",
                table: "AccumulatePointsRules",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "AccumulatePoints",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Money",
                table: "AccumulatePoints",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 13, 41, 58, 847, DateTimeKind.Local).AddTicks(7854), new DateTime(2022, 8, 3, 13, 41, 58, 847, DateTimeKind.Local).AddTicks(7871), new DateTime(2022, 8, 3, 13, 41, 58, 847, DateTimeKind.Local).AddTicks(7866) });
        }
    }
}
