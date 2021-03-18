using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class initremoteserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b0c1595-e9f1-4228-80f3-32fc1ed77e03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46087182-5081-48fa-ae79-772dfc1a63ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4c44565-a745-4344-9f08-62fcd24ebd81");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "350bb13f-7b6f-45e3-8dfe-a41bf3f87168", "1137cb7e-fc32-43f2-9c12-f09a5a6c040d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00c566d6-4786-4fa8-ba28-02862070f667", "4802b051-f142-4275-90b5-771402fccba0", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19f8dfbd-326b-45c3-9f20-8fee44a98e6d", "6114f5f2-7d2f-4295-b116-5578a54d9a58", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00c566d6-4786-4fa8-ba28-02862070f667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19f8dfbd-326b-45c3-9f20-8fee44a98e6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350bb13f-7b6f-45e3-8dfe-a41bf3f87168");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46087182-5081-48fa-ae79-772dfc1a63ef", "1608755c-2bbc-45ef-b4b1-4231a1b89e2e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4c44565-a745-4344-9f08-62fcd24ebd81", "214c4ab8-456c-4694-b5f5-8fedf56d156c", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b0c1595-e9f1-4228-80f3-32fc1ed77e03", "73a72c9b-8917-4907-9500-d5864d5b6baa", "Employee", "EMPLOYEE" });
        }
    }
}
