using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class NullableToAccumulatePointRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccumulatePoints_AccumulatePointsRules_AccumulatePointsRulesId",
                table: "AccumulatePoints");

            migrationBuilder.AlterColumn<int>(
                name: "AccumulatePointsRulesId",
                table: "AccumulatePoints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 5, 17, 11, 54, 850, DateTimeKind.Local).AddTicks(672), new DateTime(2022, 8, 5, 17, 11, 54, 850, DateTimeKind.Local).AddTicks(688), new DateTime(2022, 8, 5, 17, 11, 54, 850, DateTimeKind.Local).AddTicks(685) });

            migrationBuilder.AddForeignKey(
                name: "FK_AccumulatePoints_AccumulatePointsRules_AccumulatePointsRulesId",
                table: "AccumulatePoints",
                column: "AccumulatePointsRulesId",
                principalTable: "AccumulatePointsRules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccumulatePoints_AccumulatePointsRules_AccumulatePointsRulesId",
                table: "AccumulatePoints");

            migrationBuilder.AlterColumn<int>(
                name: "AccumulatePointsRulesId",
                table: "AccumulatePoints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DateOfRecord", "IssueDate" },
                values: new object[] { new DateTime(2022, 8, 5, 8, 47, 32, 107, DateTimeKind.Local).AddTicks(4877), new DateTime(2022, 8, 5, 8, 47, 32, 107, DateTimeKind.Local).AddTicks(4892), new DateTime(2022, 8, 5, 8, 47, 32, 107, DateTimeKind.Local).AddTicks(4889) });

            migrationBuilder.AddForeignKey(
                name: "FK_AccumulatePoints_AccumulatePointsRules_AccumulatePointsRulesId",
                table: "AccumulatePoints",
                column: "AccumulatePointsRulesId",
                principalTable: "AccumulatePointsRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
