using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class ItemInstanceInstanceIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ef8ab70-7946-47a6-99ff-8d906a1b9a6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73fa2ebe-3716-4c64-ae53-f38194964cda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e45d53f-49a9-460b-8e12-2bd0bfab6ef1");

            migrationBuilder.AddColumn<string>(
                name: "InstanceIdentifier",
                table: "ItemInStorages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2e1c51c-792e-4be1-bfbd-08386213b536", "64939bb1-9214-4d4e-82d2-812029633543", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c85b0ade-4546-4513-9eda-12fed7995fb5", "16cc2d10-9924-4854-bac1-46d6fe831ae2", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fe69a3f-395a-4301-bef2-1dc32688cde9", "5ace7884-0336-4856-8127-29fd65f3be34", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe69a3f-395a-4301-bef2-1dc32688cde9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c85b0ade-4546-4513-9eda-12fed7995fb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2e1c51c-792e-4be1-bfbd-08386213b536");

            migrationBuilder.DropColumn(
                name: "InstanceIdentifier",
                table: "ItemInStorages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e45d53f-49a9-460b-8e12-2bd0bfab6ef1", "41011dd3-ac3c-4416-95e3-aab5b22bf4af", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73fa2ebe-3716-4c64-ae53-f38194964cda", "897bf9f0-ea93-4ab2-82a5-e40fcdf274d3", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ef8ab70-7946-47a6-99ff-8d906a1b9a6f", "7afce334-00a6-4491-8ea6-0a2eb1219c27", "Employee", "EMPLOYEE" });
        }
    }
}
