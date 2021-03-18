using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class initremote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d15f7ab-daa3-4be9-8d2a-cdd9bc7aca20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a2cee3-62cb-4adb-8962-5ce39bf54162");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5877253-8af7-41b5-9912-ed515d44cfaf");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7d15f7ab-daa3-4be9-8d2a-cdd9bc7aca20", "6c6299de-b83f-4069-87ab-5dea24c6f5cb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3a2cee3-62cb-4adb-8962-5ce39bf54162", "7e39deae-2cd7-470c-91e4-9a2bf53aedb8", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5877253-8af7-41b5-9912-ed515d44cfaf", "2258cafe-a4ea-493e-b292-372395a59ef2", "Employee", "EMPLOYEE" });
        }
    }
}
