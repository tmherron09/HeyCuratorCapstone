using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class CurRolICollCurSp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "9fda9807-aab5-46c3-8197-43115e5b074a", "04db6452-91b9-4b96-8c64-92e0f14a3a56", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70c0be25-09fe-40f4-b4ba-ea6bd3b163e2", "59eef87e-a994-4fcf-9c53-a9caf0ae924f", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7ea4540-fe72-4b9b-a28b-518c52b5272f", "7479b8b3-f72d-43d4-b3b8-8472ad9c6b72", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70c0be25-09fe-40f4-b4ba-ea6bd3b163e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fda9807-aab5-46c3-8197-43115e5b074a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ea4540-fe72-4b9b-a28b-518c52b5272f");

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
    }
}
