using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_basm_Server.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuratorRoles",
                columns: table => new
                {
                    CuratorRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratorRoles", x => x.CuratorRoleId);
                });

            migrationBuilder.CreateTable(
                name: "CuratorSpaces",
                columns: table => new
                {
                    CuratorSpaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratorSpaces", x => x.CuratorSpaceId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IdentityUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MinCount = table.Column<int>(nullable: false),
                    DaysBetweenUpdates = table.Column<int>(nullable: false),
                    DaysBeforeNotifyAllCurators = table.Column<int>(nullable: false),
                    DateOfLastUpdate = table.Column<DateTime>(nullable: false),
                    UpdateByDate = table.Column<DateTime>(nullable: false),
                    DateNotifyCurators = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StorageType = table.Column<int>(nullable: false),
                    AccessLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitSpaces",
                columns: table => new
                {
                    ExhibitSpaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitSpaceName = table.Column<string>(nullable: true),
                    CuratorSpaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitSpaces", x => x.ExhibitSpaceId);
                    table.ForeignKey(
                        name: "FK_ExhibitSpaces_CuratorSpaces_CuratorSpaceId",
                        column: x => x.CuratorSpaceId,
                        principalTable: "CuratorSpaces",
                        principalColumn: "CuratorSpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curators",
                columns: table => new
                {
                    CuratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curators", x => x.CuratorId);
                    table.ForeignKey(
                        name: "FK_Curators_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    AmountInOrder = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    PurchaserNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaserNotifications",
                columns: table => new
                {
                    PurchaserNotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    CurrentStock = table.Column<int>(nullable: false),
                    AmountRequested = table.Column<int>(nullable: true),
                    OrderUrgency = table.Column<int>(nullable: false),
                    CuratorNote = table.Column<string>(nullable: true),
                    PurchaserNote = table.Column<string>(nullable: true),
                    OrderRefId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaserNotifications", x => x.PurchaserNotificationId);
                    table.ForeignKey(
                        name: "FK_PurchaserNotifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaserNotifications_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageCuratorSpaces",
                columns: table => new
                {
                    StorageCuratorSpacesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageId = table.Column<int>(nullable: false),
                    CuratorSpaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageCuratorSpaces", x => x.StorageCuratorSpacesId);
                    table.ForeignKey(
                        name: "FK_StorageCuratorSpaces_CuratorSpaces_CuratorSpaceId",
                        column: x => x.CuratorSpaceId,
                        principalTable: "CuratorSpaces",
                        principalColumn: "CuratorSpaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageCuratorSpaces_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibits",
                columns: table => new
                {
                    ExhibitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CuratorSpaceId = table.Column<int>(nullable: false),
                    ExhibitSpaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibits", x => x.ExhibitId);
                    table.ForeignKey(
                        name: "FK_Exhibits_CuratorSpaces_CuratorSpaceId",
                        column: x => x.CuratorSpaceId,
                        principalTable: "CuratorSpaces",
                        principalColumn: "CuratorSpaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exhibits_ExhibitSpaces_ExhibitSpaceId",
                        column: x => x.ExhibitSpaceId,
                        principalTable: "ExhibitSpaces",
                        principalColumn: "ExhibitSpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuratorAssignments",
                columns: table => new
                {
                    CuratorAssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuratorId = table.Column<int>(nullable: false),
                    CuratorSpaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratorAssignments", x => x.CuratorAssignmentId);
                    table.ForeignKey(
                        name: "FK_CuratorAssignments_Curators_CuratorId",
                        column: x => x.CuratorId,
                        principalTable: "Curators",
                        principalColumn: "CuratorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuratorAssignments_CuratorSpaces_CuratorSpaceId",
                        column: x => x.CuratorSpaceId,
                        principalTable: "CuratorSpaces",
                        principalColumn: "CuratorSpaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemInStorages",
                columns: table => new
                {
                    ItemInStorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageCount = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false),
                    CuratorSpaceId = table.Column<int>(nullable: true),
                    CuratorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInStorages", x => x.ItemInStorageId);
                    table.ForeignKey(
                        name: "FK_ItemInStorages_Curators_CuratorId",
                        column: x => x.CuratorId,
                        principalTable: "Curators",
                        principalColumn: "CuratorId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "RecordInfo",
                columns: table => new
                {
                    RecordInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordId = table.Column<int>(nullable: false),
                    CuratorId = table.Column<int>(nullable: true),
                    FirstVerifierId = table.Column<int>(nullable: true),
                    SecondVefifierId = table.Column<int>(nullable: true),
                    CuratorVerified = table.Column<bool>(nullable: false),
                    IsChallenged = table.Column<bool>(nullable: false),
                    SecondaryVefified = table.Column<bool>(nullable: false),
                    RecordNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordInfo", x => x.RecordInfoId);
                    table.ForeignKey(
                        name: "FK_RecordInfo_Curators_CuratorId",
                        column: x => x.CuratorId,
                        principalTable: "Curators",
                        principalColumn: "CuratorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecordInfo_Employees_FirstVerifierId",
                        column: x => x.FirstVerifierId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecordInfo_Employees_SecondVefifierId",
                        column: x => x.SecondVefifierId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitItemInStorages",
                columns: table => new
                {
                    ExhibitItemInStorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitId = table.Column<int>(nullable: false),
                    ItemInStorageId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordedCount = table.Column<int>(nullable: false),
                    ItemInStorageId = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    RecordInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_RecordInfo_RecordInfoId",
                        column: x => x.RecordInfoId,
                        principalTable: "RecordInfo",
                        principalColumn: "RecordInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuratorAssignments_CuratorId",
                table: "CuratorAssignments",
                column: "CuratorId");

            migrationBuilder.CreateIndex(
                name: "IX_CuratorAssignments_CuratorSpaceId",
                table: "CuratorAssignments",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Curators_EmployeeId",
                table: "Curators",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitItemInStorages_ExhibitId",
                table: "ExhibitItemInStorages",
                column: "ExhibitId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitItemInStorages_ItemInStorageId",
                table: "ExhibitItemInStorages",
                column: "ItemInStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_CuratorSpaceId",
                table: "Exhibits",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_ExhibitSpaceId",
                table: "Exhibits",
                column: "ExhibitSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitSpaces_CuratorSpaceId",
                table: "ExhibitSpaces",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInStorages_CuratorId",
                table: "ItemInStorages",
                column: "CuratorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaserNotifications_EmployeeId",
                table: "PurchaserNotifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaserNotifications_ItemId",
                table: "PurchaserNotifications",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordInfo_CuratorId",
                table: "RecordInfo",
                column: "CuratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordInfo_FirstVerifierId",
                table: "RecordInfo",
                column: "FirstVerifierId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordInfo_SecondVefifierId",
                table: "RecordInfo",
                column: "SecondVefifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_RecordInfoId",
                table: "Records",
                column: "RecordInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageCuratorSpaces_CuratorSpaceId",
                table: "StorageCuratorSpaces",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageCuratorSpaces_StorageId",
                table: "StorageCuratorSpaces",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuratorAssignments");

            migrationBuilder.DropTable(
                name: "CuratorRoles");

            migrationBuilder.DropTable(
                name: "ExhibitItemInStorages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PurchaserNotifications");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "StorageCuratorSpaces");

            migrationBuilder.DropTable(
                name: "Exhibits");

            migrationBuilder.DropTable(
                name: "ItemInStorages");

            migrationBuilder.DropTable(
                name: "RecordInfo");

            migrationBuilder.DropTable(
                name: "ExhibitSpaces");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Curators");

            migrationBuilder.DropTable(
                name: "CuratorSpaces");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
