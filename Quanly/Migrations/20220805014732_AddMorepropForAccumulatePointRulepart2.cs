using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class AddMorepropForAccumulatePointRulepart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AccumulatePointsRules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 5, 8, 47, 32, 107, DateTimeKind.Local).AddTicks(4877), new DateTime(2022, 8, 5, 8, 47, 32, 107, DateTimeKind.Local).AddTicks(4892), new DateTime(2022, 8, 5, 8, 47, 32, 107, DateTimeKind.Local).AddTicks(4889) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AccumulatePointsRules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 5, 8, 46, 34, 595, DateTimeKind.Local).AddTicks(6248), new DateTime(2022, 8, 5, 8, 46, 34, 595, DateTimeKind.Local).AddTicks(6267), new DateTime(2022, 8, 5, 8, 46, 34, 595, DateTimeKind.Local).AddTicks(6264) });
        }
    }
}
