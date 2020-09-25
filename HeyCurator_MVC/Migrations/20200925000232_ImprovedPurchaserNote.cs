using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class ImprovedPurchaserNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a6c4a5b-ab1d-417a-954f-6007aa22187a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb24dc97-f714-4478-85e9-b348b3017c9e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee284f08-25e6-4f9b-9672-a49f217918f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73089899-7552-46a5-9e81-4d20469bc488", "c11c2d43-55c7-4c77-b7b4-6dd664d731a1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a60b766-6a97-4233-ab19-c7f04bebeacd", "c2dbab30-2742-48f3-bbf3-114ca337d331", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d81ef23f-9224-42ae-8ead-a13d2949ef01", "8a7e000d-d54c-49f8-9b95-df4294279a21", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a60b766-6a97-4233-ab19-c7f04bebeacd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73089899-7552-46a5-9e81-4d20469bc488");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d81ef23f-9224-42ae-8ead-a13d2949ef01");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb24dc97-f714-4478-85e9-b348b3017c9e", "f7809a26-8775-4f53-8d6f-f8198bad04e7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a6c4a5b-ab1d-417a-954f-6007aa22187a", "0ef65759-fc5f-45ab-8425-b3ee99107ebb", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee284f08-25e6-4f9b-9672-a49f217918f9", "a5215f67-db23-4a41-a62f-ee21343ff18f", "Employee", "EMPLOYEE" });
        }
    }
}
