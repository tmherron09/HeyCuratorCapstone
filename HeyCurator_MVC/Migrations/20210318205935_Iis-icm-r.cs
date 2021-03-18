using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class Iisicmr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be5a650-6de9-4491-856f-c0988614e3af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a084c5a0-d102-4d6b-90f0-4304d2773b2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d78d3637-a624-4188-adfc-f7a8019bf524");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "669cf77d-bbec-4a6b-8f9b-b24c449004f1", "e94bf556-74a2-455b-be65-428457b248a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a070e1ad-b240-47e6-9490-87e5dae9d948", "e0136fa9-a246-4a61-b952-2c50183e9d35", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e689b56e-3d5d-4488-acb1-787a518a42e2", "b827f824-d60e-451a-9533-5b33099f4b06", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "669cf77d-bbec-4a6b-8f9b-b24c449004f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a070e1ad-b240-47e6-9490-87e5dae9d948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e689b56e-3d5d-4488-acb1-787a518a42e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d78d3637-a624-4188-adfc-f7a8019bf524", "09fbb002-56b1-48a1-9e74-85633902acf0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8be5a650-6de9-4491-856f-c0988614e3af", "d073ecec-ac3a-4b9b-bc61-d833b017fdb1", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a084c5a0-d102-4d6b-90f0-4304d2773b2a", "f3e3cf9b-a218-4530-b91c-a13a71e99a02", "Employee", "EMPLOYEE" });
        }
    }
}
