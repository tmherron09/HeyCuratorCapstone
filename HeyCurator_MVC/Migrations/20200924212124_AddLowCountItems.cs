using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class AddLowCountItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "287df825-7ca3-4cc9-ba20-88ff45b7fddd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f492bc6-bc3f-4db3-a387-b706446e2cb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f519b46-cb8f-4c46-ae4a-d6eea223ba5f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cfa8c64-602c-4005-8f1d-c782aab6ac38");

            migrationBuilder.AddColumn<bool>(
                name: "IsFullFilled",
                table: "PurchaserNotifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LowCountItems",
                columns: table => new
                {
                    ExpiredUpdateItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    AmountInReserve = table.Column<int>(nullable: false),
                    PurchaseNotificationMade = table.Column<bool>(nullable: false),
                    OrderHasBeenMade = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LowCountItems", x => x.ExpiredUpdateItemId);
                    table.ForeignKey(
                        name: "FK_LowCountItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LowCountItems_ItemId",
                table: "LowCountItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LowCountItems");

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

            migrationBuilder.DropColumn(
                name: "IsFullFilled",
                table: "PurchaserNotifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f492bc6-bc3f-4db3-a387-b706446e2cb0", "fcacb28b-8473-4d06-9672-d576903402d6", "Admin", "ADMIN" },
                    { "287df825-7ca3-4cc9-ba20-88ff45b7fddd", "250c1b59-6c50-4d09-b854-04827efba25a", "Curator", "CURATOR" },
                    { "9f519b46-cb8f-4c46-ae4a-d6eea223ba5f", "8c58a743-934f-434a-86e0-afa041ecb2ee", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2cfa8c64-602c-4005-8f1d-c782aab6ac38", 0, "ebe1a757-1673-4c34-8b97-b702bc5a2bc5", "Admin@admin.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOZMRBKFYjU4nG+pWGj6PHT1PcftraGfdhAlnPGfXAyVZh4cGmiToxqw0rqicLCx1A==", null, false, "9bcda4e7-deb6-4c53-ac21-7d25bfdf7f0b", false, "Admin" });
        }
    }
}
