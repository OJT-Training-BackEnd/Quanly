using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class FixModelBaseDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "MemberCards");

            migrationBuilder.DropColumn(
                name: "Updater",
                table: "MemberCards");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Updater",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "AccumulatePointsRules");

            migrationBuilder.DropColumn(
                name: "Updater",
                table: "AccumulatePointsRules");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "AccumulatePoints");

            migrationBuilder.DropColumn(
                name: "Updater",
                table: "AccumulatePoints");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "MemberCards",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateAdded", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 12, 48, 4, 885, DateTimeKind.Local).AddTicks(3677), new DateTime(2022, 8, 3, 12, 48, 4, 885, DateTimeKind.Local).AddTicks(3674), new DateTime(2022, 8, 3, 12, 48, 4, 885, DateTimeKind.Local).AddTicks(3680), new DateTime(2022, 8, 3, 12, 48, 4, 885, DateTimeKind.Local).AddTicks(3678) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "MemberCards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "MemberCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updater",
                table: "MemberCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updater",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "AccumulatePointsRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updater",
                table: "AccumulatePointsRules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "AccumulatePoints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updater",
                table: "AccumulatePoints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateAdded", "DateOfRecord", "DateUpdated", "IssueDate", "Updater" },
                values: new object[] { new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9687), new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9682), new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9691), new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9683), new DateTime(2022, 8, 3, 9, 9, 55, 79, DateTimeKind.Local).AddTicks(9687), "Ad" });
        }
    }
}
