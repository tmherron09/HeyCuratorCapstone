using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class ReInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmployeeUserName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
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
                    Name = table.Column<string>(nullable: false),
                    MinCount = table.Column<int>(nullable: false),
                    DaysBetweenUpdates = table.Column<int>(nullable: false),
                    DaysBeforeNotifyAllCurators = table.Column<int>(nullable: false),
                    DateOfLastUpdate = table.Column<DateTime>(nullable: false),
                    UpdateByDate = table.Column<DateTime>(nullable: false),
                    DateNotifyCurators = table.Column<DateTime>(nullable: false),
                    RecordedStorageAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    CuratorRoleId = table.Column<int>(nullable: false),
                    StaffRoleCuratorRoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.EmployeeRoleId);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_CuratorRoles_CuratorRoleId",
                        column: x => x.CuratorRoleId,
                        principalTable: "CuratorRoles",
                        principalColumn: "CuratorRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_CuratorRoles_StaffRoleCuratorRoleId",
                        column: x => x.StaffRoleCuratorRoleId,
                        principalTable: "CuratorRoles",
                        principalColumn: "CuratorRoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeyCuratorMails",
                columns: table => new
                {
                    HeyCuratorMailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(nullable: true),
                    RecipientId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    MessageContent = table.Column<string>(nullable: false),
                    DateMessageSent = table.Column<DateTime>(nullable: false),
                    HasBeenRead = table.Column<bool>(nullable: false),
                    SenderDeleted = table.Column<bool>(nullable: false),
                    RecipientDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeyCuratorMails", x => x.HeyCuratorMailId);
                    table.ForeignKey(
                        name: "FK_HeyCuratorMails_Employees_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeyCuratorMails_Employees_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordInfo",
                columns: table => new
                {
                    RecordInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
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
                        name: "FK_RecordInfo_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
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
                name: "CuratorSpaces",
                columns: table => new
                {
                    CuratorSpaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CuratorRoleId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratorSpaces", x => x.CuratorSpaceId);
                    table.ForeignKey(
                        name: "FK_CuratorSpaces_CuratorRoles_CuratorRoleId",
                        column: x => x.CuratorRoleId,
                        principalTable: "CuratorRoles",
                        principalColumn: "CuratorRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuratorSpaces_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpiredUpdateItems",
                columns: table => new
                {
                    ExpiredUpdateItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    AllCuratorExpiration = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpiredUpdateItems", x => x.ExpiredUpdateItemId);
                    table.ForeignKey(
                        name: "FK_ExpiredUpdateItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
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
                name: "ExhibitSpaces",
                columns: table => new
                {
                    ExhibitSpaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitSpaceName = table.Column<string>(nullable: true),
                    CuratorSpaceId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_ExhibitSpaces_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StorageType = table.Column<string>(nullable: true),
                    AccessLevel = table.Column<int>(nullable: false),
                    CuratorSpaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                    table.ForeignKey(
                        name: "FK_Storages_CuratorSpaces_CuratorSpaceId",
                        column: x => x.CuratorSpaceId,
                        principalTable: "CuratorSpaces",
                        principalColumn: "CuratorSpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exhibits",
                columns: table => new
                {
                    ExhibitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CuratorSpaceId = table.Column<int>(nullable: false),
                    ExhibitSpaceId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: true)
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exhibits_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ItemInStorages",
                columns: table => new
                {
                    ItemInStorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageCount = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false),
                    CuratorSpaceId = table.Column<int>(nullable: true),
                    ExhibitId = table.Column<int>(nullable: true)
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
                        name: "FK_ItemInStorages_Exhibits_ExhibitId",
                        column: x => x.ExhibitId,
                        principalTable: "Exhibits",
                        principalColumn: "ExhibitId",
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
                    RecordInfoId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Records_ItemInStorages_ItemInStorageId",
                        column: x => x.ItemInStorageId,
                        principalTable: "ItemInStorages",
                        principalColumn: "ItemInStorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_RecordInfo_RecordInfoId",
                        column: x => x.RecordInfoId,
                        principalTable: "RecordInfo",
                        principalColumn: "RecordInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c4724412-4815-484c-8f9c-35aeea1f9fa0", "738b2e3a-b150-41b1-aafc-c20e1d48e17b", "Admin", "ADMIN" },
                    { "ebe857d9-5eb1-441a-bf3d-5ce4e1a1f44c", "ee0333d5-934f-48fc-85a2-da704c16ff8c", "Curator", "CURATOR" },
                    { "75f534c2-787c-471e-9f53-9bf721d88afe", "f4ea9af5-4639-4dfe-9ca1-20a2d17af0c2", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de62c94d-57ee-42c5-a3b9-b8560c0a4df8", 0, "65478f41-a364-4a4f-a1d2-07bbafca5a89", "Admin@admin.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJLxTKqvmknQ/xX6lFJSEV8g622/2ffFHfwp/Xdw76NDqpW8S17TWJVjlzc/WL/oUw==", null, false, "696bcb52-6269-42b2-a377-942fc7c8e02d", false, "Admin" });

            migrationBuilder.InsertData(
                table: "CuratorRoles",
                columns: new[] { "CuratorRoleId", "NameOfRole" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Employee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CuratorSpaces_CuratorRoleId",
                table: "CuratorSpaces",
                column: "CuratorRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CuratorSpaces_ItemId",
                table: "CuratorSpaces",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_CuratorRoleId",
                table: "EmployeeRoles",
                column: "CuratorRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_StaffRoleCuratorRoleId",
                table: "EmployeeRoles",
                column: "StaffRoleCuratorRoleId");

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
                name: "IX_Exhibits_ItemId",
                table: "Exhibits",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitSpaces_CuratorSpaceId",
                table: "ExhibitSpaces",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitSpaces_ItemId",
                table: "ExhibitSpaces",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpiredUpdateItems_ItemId",
                table: "ExpiredUpdateItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HeyCuratorMails_RecipientId",
                table: "HeyCuratorMails",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_HeyCuratorMails_SenderId",
                table: "HeyCuratorMails",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInStorages_CuratorSpaceId",
                table: "ItemInStorages",
                column: "CuratorSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInStorages_ExhibitId",
                table: "ItemInStorages",
                column: "ExhibitId");

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
                name: "IX_RecordInfo_EmployeeId",
                table: "RecordInfo",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordInfo_FirstVerifierId",
                table: "RecordInfo",
                column: "FirstVerifierId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordInfo_SecondVefifierId",
                table: "RecordInfo",
                column: "SecondVefifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ItemId",
                table: "Records",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ItemInStorageId",
                table: "Records",
                column: "ItemInStorageId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Storages_CuratorSpaceId",
                table: "Storages",
                column: "CuratorSpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "ExhibitItemInStorages");

            migrationBuilder.DropTable(
                name: "ExpiredUpdateItems");

            migrationBuilder.DropTable(
                name: "HeyCuratorMails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PurchaserNotifications");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "StorageCuratorSpaces");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ItemInStorages");

            migrationBuilder.DropTable(
                name: "RecordInfo");

            migrationBuilder.DropTable(
                name: "Exhibits");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ExhibitSpaces");

            migrationBuilder.DropTable(
                name: "CuratorSpaces");

            migrationBuilder.DropTable(
                name: "CuratorRoles");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
