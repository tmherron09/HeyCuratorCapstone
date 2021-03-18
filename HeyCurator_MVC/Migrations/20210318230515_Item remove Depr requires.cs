using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class ItemremoveDeprrequires : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuratorSpaces_Items_ItemId",
                table: "CuratorSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibits_Items_ItemId",
                table: "Exhibits");

            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitSpaces_Items_ItemId",
                table: "ExhibitSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Items_ItemId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_ItemId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_ExhibitSpaces_ItemId",
                table: "ExhibitSpaces");

            migrationBuilder.DropIndex(
                name: "IX_Exhibits_ItemId",
                table: "Exhibits");

            migrationBuilder.DropIndex(
                name: "IX_CuratorSpaces_ItemId",
                table: "CuratorSpaces");

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

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ExhibitSpaces");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Exhibits");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "CuratorSpaces");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5e826b1-f9ff-42c8-8493-b8b47513d3a6", "6517373d-765b-442e-ae94-aae88b9eb02d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a32711d-2637-4056-9282-47da7eee7d58", "edde2549-65cd-401e-bb06-177b6e8053df", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f94f6f28-8a14-4c3e-af2e-f964d6605da8", "f87f0396-88c5-4faf-9f58-657e449f6394", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a32711d-2637-4056-9282-47da7eee7d58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5e826b1-f9ff-42c8-8493-b8b47513d3a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f94f6f28-8a14-4c3e-af2e-f964d6605da8");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Records",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ExhibitSpaces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Exhibits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "CuratorSpaces",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Records_ItemId",
                table: "Records",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitSpaces_ItemId",
                table: "ExhibitSpaces",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_ItemId",
                table: "Exhibits",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CuratorSpaces_ItemId",
                table: "CuratorSpaces",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuratorSpaces_Items_ItemId",
                table: "CuratorSpaces",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibits_Items_ItemId",
                table: "Exhibits",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitSpaces_Items_ItemId",
                table: "ExhibitSpaces",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Items_ItemId",
                table: "Records",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
