using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class AddMorepropForAccumulatePointRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AccumulatePointsRules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 5, 8, 46, 34, 595, DateTimeKind.Local).AddTicks(6248), new DateTime(2022, 8, 5, 8, 46, 34, 595, DateTimeKind.Local).AddTicks(6267), new DateTime(2022, 8, 5, 8, 46, 34, 595, DateTimeKind.Local).AddTicks(6264) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AccumulatePointsRules");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 3, 21, 6, 28, 996, DateTimeKind.Local).AddTicks(4098), new DateTime(2022, 8, 3, 21, 6, 28, 996, DateTimeKind.Local).AddTicks(4112), new DateTime(2022, 8, 3, 21, 6, 28, 996, DateTimeKind.Local).AddTicks(4109) });
        }
    }
}
