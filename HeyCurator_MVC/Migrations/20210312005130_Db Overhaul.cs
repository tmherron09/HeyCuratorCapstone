﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class DbOverhaul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnonymousQuestions",
                columns: table => new
                {
                    AnonymousQuestionId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TimePosted = table.Column<DateTime>(nullable: false),
                    QuestionHeader = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonymousQuestions", x => x.AnonymousQuestionId);
                });

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
                name: "ChatMessages",
                columns: table => new
                {
                    ChatMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.ChatMessageId);
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
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ItemDescription = table.Column<string>(nullable: true),
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
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LocationDescription = table.Column<string>(nullable: true),
                    RestrictedAccessRules = table.Column<string>(nullable: true),
                    StorageType = table.Column<string>(nullable: true),
                    AccessLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                });

            migrationBuilder.CreateTable(
                name: "AnonymousComments",
                columns: table => new
                {
                    AnonymousCommentId = table.Column<Guid>(nullable: false),
                    AnonymousQuestionId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    CommentBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonymousComments", x => x.AnonymousCommentId);
                    table.ForeignKey(
                        name: "FK_AnonymousComments_AnonymousQuestions_AnonymousQuestionId",
                        column: x => x.AnonymousQuestionId,
                        principalTable: "AnonymousQuestions",
                        principalColumn: "AnonymousQuestionId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ItemInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemInstanceName = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInstances_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ExhibitSpaces",
                columns: table => new
                {
                    ExhibitSpaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitSpaceName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LocationDescription = table.Column<string>(nullable: true),
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
                name: "ItemInStorages",
                columns: table => new
                {
                    ItemInStorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceIdentifier = table.Column<string>(nullable: true),
                    StorageCount = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false),
                    CuratorSpaceId = table.Column<int>(nullable: true)
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
                name: "InventoryControlModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemInstanceId = table.Column<int>(nullable: false),
                    UnitMeasurement = table.Column<string>(nullable: true),
                    MinimumUnitCount = table.Column<float>(nullable: false),
                    RecommendedUnitCount = table.Column<float>(nullable: false),
                    MostRecentInventoryCount = table.Column<int>(nullable: false),
                    DateOfMostRecentInventoryCount = table.Column<DateTime>(nullable: false),
                    ScheduledUpdatePeriodInDays = table.Column<int>(nullable: false),
                    AllowUpdateLapseInDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryControlModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryControlModels_ItemInstances_ItemInstanceId",
                        column: x => x.ItemInstanceId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageItemInstances",
                columns: table => new
                {
                    ItemInstanceId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageItemInstances", x => new { x.StorageId, x.ItemInstanceId });
                    table.ForeignKey(
                        name: "FK_StorageItemInstances_ItemInstances_ItemInstanceId",
                        column: x => x.ItemInstanceId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageItemInstances_Storages_StorageId",
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
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LocationDescription = table.Column<string>(nullable: true),
                    ExhibitSpaceId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibits", x => x.ExhibitId);
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
                name: "ExhibitItemInstances",
                columns: table => new
                {
                    ExhibitId = table.Column<int>(nullable: false),
                    ItemInstanceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitItemInstances", x => new { x.ExhibitId, x.ItemInstanceId });
                    table.ForeignKey(
                        name: "FK_ExhibitItemInstances_Exhibits_ExhibitId",
                        column: x => x.ExhibitId,
                        principalTable: "Exhibits",
                        principalColumn: "ExhibitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitItemInstances_ItemInstances_ItemInstanceId",
                        column: x => x.ItemInstanceId,
                        principalTable: "ItemInstances",
                        principalColumn: "Id",
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
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    CuratorRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => new { x.EmployeeId, x.CuratorRoleId });
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_CuratorRoles_CuratorRoleId",
                        column: x => x.CuratorRoleId,
                        principalTable: "CuratorRoles",
                        principalColumn: "CuratorRoleId",
                        onDelete: ReferentialAction.Cascade);
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
                    RecipientDeleted = table.Column<bool>(nullable: false),
                    ResponseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeyCuratorMails", x => x.HeyCuratorMailId);
                    table.ForeignKey(
                        name: "FK_HeyCuratorMails_HeyCuratorMails_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "HeyCuratorMails",
                        principalColumn: "HeyCuratorMailId",
                        onDelete: ReferentialAction.Restrict);
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
                    OrderRefId = table.Column<int>(nullable: true),
                    IsFullFilled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaserNotifications", x => x.PurchaserNotificationId);
                    table.ForeignKey(
                        name: "FK_PurchaserNotifications_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordedCount = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    CuratorVerified = table.Column<bool>(nullable: false),
                    RecordNote = table.Column<string>(nullable: true),
                    InventoryControlModelID = table.Column<int>(nullable: false),
                    ItemInStorageId = table.Column<int>(nullable: false),
                    FirstVerifierId = table.Column<int>(nullable: true),
                    SecondVefifierId = table.Column<int>(nullable: true),
                    IsChallenged = table.Column<bool>(nullable: false),
                    SecondaryVefified = table.Column<bool>(nullable: false),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_InventoryControlModels_InventoryControlModelID",
                        column: x => x.InventoryControlModelID,
                        principalTable: "InventoryControlModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IdentityUser = table.Column<string>(nullable: true),
                    RecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d15f7ab-daa3-4be9-8d2a-cdd9bc7aca20", "6c6299de-b83f-4069-87ab-5dea24c6f5cb", "Admin", "ADMIN" },
                    { "c3a2cee3-62cb-4adb-8962-5ce39bf54162", "7e39deae-2cd7-470c-91e4-9a2bf53aedb8", "Curator", "CURATOR" },
                    { "d5877253-8af7-41b5-9912-ed515d44cfaf", "2258cafe-a4ea-493e-b292-372395a59ef2", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "CuratorRoles",
                columns: new[] { "CuratorRoleId", "NameOfRole" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "StorageId", "AccessLevel", "Description", "LocationDescription", "Name", "RestrictedAccessRules", "StorageType" },
                values: new object[] { 1, 7, null, null, "Not Declared", null, "Not Declared" });

            migrationBuilder.CreateIndex(
                name: "IX_AnonymousComments_AnonymousQuestionId",
                table: "AnonymousComments",
                column: "AnonymousQuestionId");

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
                name: "IX_Employees_RecordId",
                table: "Employees",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitItemInstances_ItemInstanceId",
                table: "ExhibitItemInstances",
                column: "ItemInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitItemInStorages_ExhibitId",
                table: "ExhibitItemInStorages",
                column: "ExhibitId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitItemInStorages_ItemInStorageId",
                table: "ExhibitItemInStorages",
                column: "ItemInStorageId");

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
                name: "IX_HeyCuratorMails_ResponseId",
                table: "HeyCuratorMails",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_HeyCuratorMails_SenderId",
                table: "HeyCuratorMails",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryControlModels_ItemInstanceId",
                table: "InventoryControlModels",
                column: "ItemInstanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemInstances_ItemId",
                table: "ItemInstances",
                column: "ItemId");

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
                name: "IX_LowCountItems_ItemId",
                table: "LowCountItems",
                column: "ItemId");

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
                name: "IX_Records_EmployeeId",
                table: "Records",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_FirstVerifierId",
                table: "Records",
                column: "FirstVerifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_InventoryControlModelID",
                table: "Records",
                column: "InventoryControlModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ItemId",
                table: "Records",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ItemInStorageId",
                table: "Records",
                column: "ItemInStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_SecondVefifierId",
                table: "Records",
                column: "SecondVefifierId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageItemInstances_ItemInstanceId",
                table: "StorageItemInstances",
                column: "ItemInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRoles_Employees_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeyCuratorMails_Employees_RecipientId",
                table: "HeyCuratorMails",
                column: "RecipientId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HeyCuratorMails_Employees_SenderId",
                table: "HeyCuratorMails",
                column: "SenderId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeId",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaserNotifications_Employees_EmployeeId",
                table: "PurchaserNotifications",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Employees_EmployeeId",
                table: "Records",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Employees_FirstVerifierId",
                table: "Records",
                column: "FirstVerifierId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Employees_SecondVefifierId",
                table: "Records",
                column: "SecondVefifierId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CuratorSpaces_CuratorRoles_CuratorRoleId",
                table: "CuratorSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_CuratorSpaces_Items_ItemId",
                table: "CuratorSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInstances_Items_ItemId",
                table: "ItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemInStorages_Items_ItemId",
                table: "ItemInStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Items_ItemId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Employees_EmployeeId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Employees_FirstVerifierId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Employees_SecondVefifierId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "AnonymousComments");

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
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "ExhibitItemInstances");

            migrationBuilder.DropTable(
                name: "ExhibitItemInStorages");

            migrationBuilder.DropTable(
                name: "ExpiredUpdateItems");

            migrationBuilder.DropTable(
                name: "HeyCuratorMails");

            migrationBuilder.DropTable(
                name: "LowCountItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PurchaserNotifications");

            migrationBuilder.DropTable(
                name: "StorageItemInstances");

            migrationBuilder.DropTable(
                name: "AnonymousQuestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Exhibits");

            migrationBuilder.DropTable(
                name: "ExhibitSpaces");

            migrationBuilder.DropTable(
                name: "CuratorRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "InventoryControlModels");

            migrationBuilder.DropTable(
                name: "ItemInStorages");

            migrationBuilder.DropTable(
                name: "ItemInstances");

            migrationBuilder.DropTable(
                name: "CuratorSpaces");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
