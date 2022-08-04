using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class UnCommentSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Age", "BirthDate", "Code", "CompanyName", "CompanyPhone", "Contact", "CustomerName", "DateAdded", "DateOfRecord", "District", "Email", "Fax", "Gender", "IdentityCard", "Importer", "IsActive", "IsMarried", "IssueDate", "Language", "Note", "Phone", "Points", "Position", "Province", "TelePhone", "Type" },
                values: new object[] { 1, "District 9, Ho Chi Minh City", "20", new DateTime(2022, 8, 3, 21, 6, 28, 996, DateTimeKind.Local).AddTicks(4098), "KH123456789", "KNS", "01234567891", "An Ngo", "Cong Chinh", null, new DateTime(2022, 8, 3, 21, 6, 28, 996, DateTimeKind.Local).AddTicks(4112), "District 9", "Chinhpro@gmail.com", "+84 (8) 3823 3318", "Male", "343456771234", "Ad", true, false, new DateTime(2022, 8, 3, 21, 6, 28, 996, DateTimeKind.Local).AddTicks(4109), "Vietnamese", "", "0123456789", null, "Head of KNS", "", "01234567891", "Silver" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
