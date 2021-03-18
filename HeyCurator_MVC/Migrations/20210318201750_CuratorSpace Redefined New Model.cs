using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class CuratorSpaceRedefinedNewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExhibitSpaces_CuratorSpaces_CuratorSpaceId",
                table: "ExhibitSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_ItemInStorages_ItemInStorageId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "ExhibitItemInStorages");

            migrationBuilder.DropTable(
                name: "ItemInStorages");

            migrationBuilder.DropIndex(
                name: "IX_Records_ItemInStorageId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_ExhibitSpaces_CuratorSpaceId",
                table: "ExhibitSpaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuratorSpaces",
                table: "CuratorSpaces");

            migrationBuilder.DropIndex(
                name: "IX_CuratorSpaces_CuratorRoleId",
                table: "CuratorSpaces");

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

            migrationBuilder.DropColumn(
                name: "ItemInStorageId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "CuratorSpaceId",
                table: "ExhibitSpaces");

            migrationBuilder.DropColumn(
                name: "CuratorSpaceId",
                table: "CuratorSpaces");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CuratorSpaces");

            migrationBuilder.AddColumn<int>(
                name: "ExhibitSpaceId",
                table: "CuratorSpaces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuratorSpaces",
                table: "CuratorSpaces",
                columns: new[] { "CuratorRoleId", "ExhibitSpaceId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_CuratorSpaces_ExhibitSpaceId",
                table: "CuratorSpaces",
                column: "ExhibitSpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuratorSpaces_ExhibitSpaces_ExhibitSpaceId",
                table: "CuratorSpaces",
                column: "ExhibitSpaceId",
                principalTable: "ExhibitSpaces",
                principalColumn: "ExhibitSpaceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuratorSpaces_ExhibitSpaces_ExhibitSpaceId",
                table: "CuratorSpaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CuratorSpaces",
                table: "CuratorSpaces");

            migrationBuilder.DropIndex(
                name: "IX_CuratorSpaces_ExhibitSpaceId",
                table: "CuratorSpaces");

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

            migrationBuilder.DropColumn(
                name: "ExhibitSpaceId",
                table: "CuratorSpaces");

            migrationBuilder.AddColumn<int>(
                name: "ItemInStorageId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuratorSpaceId",
                table: "ExhibitSpaces",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CuratorSpaceId",
                table: "CuratorSpaces",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CuratorSpaces",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CuratorSpaces",
                table: "CuratorSpaces",
                column: "CuratorSpaceId");

            migrationBuilder.CreateTable(
                name: "ItemInStorages",
                columns: table => new
                {
                    ItemInStorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuratorSpaceId = table.Column<int>(type: "int", nullable: true),
                    InstanceIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StorageCount = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInStorages", x => x.ItemInStorageId);
                    table.ForeignKey(
                        name: "FK_ItemInStorages_CuratorSpaces_CuratorSpaceId",
                        column: x => x.CuratorSpaceId,
                        principalTable: "CuratorSpaces",
                        principalColumn: "CuratorSpaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemInStorages_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemInStorages_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitItemInStorages",
                columns: table => new
                {
                    ExhibitItemInStorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitId = table.Column<int>(type: "int", nullable: false),
                    ItemInStorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitItemInStorages", x => x.ExhibitItemInStorageId);
                    table.ForeignKey(
                        name: "FK_ExhibitItemInStorages_Exhibits_ExhibitId",
                        column: x => x.ExhibitId,
                        principalTable: "Exhibits",
                        principalColumn: "ExhibitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitItemInStorages_ItemInStorages_ItemInStorageId",
                        column: x => x.ItemInStorageId,
                        principalTable: "ItemInStorages",
                        principalColumn: "ItemInStorageId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Records_ItemInStorageId",
                table: "Records",
                column: "ItemInStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitSpaces_CuratorSpaceId",
                table: "ExhibitSpaces",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CuratorSpaces_CuratorRoleId",
                table: "CuratorSpaces",
                column: "CuratorRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitItemInStorages_ExhibitId",
                table: "ExhibitItemInStorages",
                column: "ExhibitId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitItemInStorages_ItemInStorageId",
                table: "ExhibitItemInStorages",
                column: "ItemInStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInStorages_CuratorSpaceId",
                table: "ItemInStorages",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInStorages_ItemId",
                table: "ItemInStorages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInStorages_StorageId",
                table: "ItemInStorages",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExhibitSpaces_CuratorSpaces_CuratorSpaceId",
                table: "ExhibitSpaces",
                column: "CuratorSpaceId",
                principalTable: "CuratorSpaces",
                principalColumn: "CuratorSpaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_ItemInStorages_ItemInStorageId",
                table: "Records",
                column: "ItemInStorageId",
                principalTable: "ItemInStorages",
                principalColumn: "ItemInStorageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
