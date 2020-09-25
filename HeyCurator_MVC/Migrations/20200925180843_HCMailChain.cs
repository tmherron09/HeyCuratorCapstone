using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyCurator_MVC.Migrations
{
    public partial class HCMailChain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "HeyCuratorMails",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f9a149d-6759-485c-b5f2-94fe6a10a2f4", "3f4b2b5d-bbf7-446d-a563-b30f00203a55", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69146749-fdc8-4481-a202-a6cd85da39b7", "659a24a5-7cd3-4a11-8dc6-d768b40552ee", "Curator", "CURATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37cbc8e6-21c6-40d7-bcec-f932126f7196", "f3a718ee-5cec-4c86-8279-985882d31d53", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_HeyCuratorMails_ResponseId",
                table: "HeyCuratorMails",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_AnonymousComments_AnonymousQuestionId",
                table: "AnonymousComments",
                column: "AnonymousQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeyCuratorMails_HeyCuratorMails_ResponseId",
                table: "HeyCuratorMails",
                column: "ResponseId",
                principalTable: "HeyCuratorMails",
                principalColumn: "HeyCuratorMailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeyCuratorMails_HeyCuratorMails_ResponseId",
                table: "HeyCuratorMails");

            migrationBuilder.DropTable(
                name: "AnonymousComments");

            migrationBuilder.DropTable(
                name: "AnonymousQuestions");

            migrationBuilder.DropIndex(
                name: "IX_HeyCuratorMails_ResponseId",
                table: "HeyCuratorMails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cbc8e6-21c6-40d7-bcec-f932126f7196");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69146749-fdc8-4481-a202-a6cd85da39b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f9a149d-6759-485c-b5f2-94fe6a10a2f4");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "HeyCuratorMails");

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
    }
}
