using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quanly.Migrations
{
    public partial class Fixnulablepart4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Age", "BirthDate", "Code", "CompanyName", "CompanyPhone", "Contact", "CustomerName", "DateAdded", "DateOfRecord", "District", "Email", "Fax", "Gender", "IdentityCard", "Importer", "IsActive", "IsMarried", "IssueDate", "Language", "Note", "Phone", "Points", "Position", "Province", "TelePhone", "Type" },
                values: new object[] { 1, "District 9, Ho Chi Minh City", 20, new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(3972), "KH123456789", "KNS", 1234567891, "An Ngo", "Cong Chinh", null, new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(4081), "District 9", "Chinhpro@gmail.com", "+84 (8) 3823 3318", "Male", "343456771234", "Ad", true, false, new DateTime(2022, 8, 3, 13, 34, 14, 704, DateTimeKind.Local).AddTicks(4078), "Vietnamese", "", 1234567891, null, "Head of KNS", "", 1234567891, "Silver" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Age", "BirthDate", "Code", "CompanyName", "CompanyPhone", "Contact", "CustomerName", "DateAdded", "DateOfRecord", "District", "Email", "Fax", "Gender", "IdentityCard", "Importer", "IsActive", "IsMarried", "IssueDate", "Language", "Note", "Phone", "Points", "Position", "Province", "TelePhone", "Type" },
                values: new object[] { 1, "District 9, Ho Chi Minh City", 20, new DateTime(2022, 8, 3, 13, 24, 0, 556, DateTimeKind.Local).AddTicks(6958), "KH123456789", "KNS", 1234567891, "An Ngo", "Cong Chinh", null, new DateTime(2022, 8, 3, 13, 24, 0, 556, DateTimeKind.Local).AddTicks(6973), "District 9", "Chinhpro@gmail.com", "+84 (8) 3823 3318", "Male", "343456771234", "Ad", true, false, new DateTime(2022, 8, 3, 13, 24, 0, 556, DateTimeKind.Local).AddTicks(6970), "Vietnamese", "", 1234567891, null, "Head of KNS", "", 1234567891, "Silver" });
        }
    }
}
