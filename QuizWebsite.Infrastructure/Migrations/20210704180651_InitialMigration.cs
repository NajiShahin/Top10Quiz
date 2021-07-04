using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizWebsite.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true),
                    ExtraInfo = table.Column<string>(nullable: true),
                    QuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-100000000001"), "Countries" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CategoryId", "QuestionText" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-100000000001"), "What are the biggest countries of the world?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CategoryId", "QuestionText" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-100000000001"), "What countries have the biggest population?" });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "Id", "AnswerText", "ExtraInfo", "Points", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("094b7df9-86f4-4fe6-b111-f4c84e6dd891"), "Russia", "17,098,242 Km²", 1, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("7b7a7c61-630b-47b9-aa96-affe99dea101"), "Bangladesh", "164,689,383", 8, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("14bc3c2a-72c4-4c24-9d29-c2faca41478f"), "Nigeria", "206,139,589", 7, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("e458eed1-7b94-405d-8112-03070b77780d"), "Brazil", "212,559,417", 6, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("47e649af-ecb6-4a28-b33f-625eec660823"), "Pakistan", "220,892,340", 5, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("2b69a7eb-d1ff-4143-8320-e1b1c33d5d8f"), "Indonesia", "273,523,615", 4, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("59d62492-84b5-4b38-a6a3-83de26ddfc4e"), "United States", "331,002,651", 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("e0766d49-dfc6-4eca-b8a3-672f8953c78f"), "The United States", "331,002,651", 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("46c36bcb-4e0d-4f37-8447-26312c0b3023"), "USA", "331,002,651", 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("beb8946e-0481-4ffe-96a0-1900869a4dfa"), "India", "1,380,004,385", 2, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("97c325d1-9ef6-401f-b353-3aee47a96919"), "China", "1,439,323,776", 1, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("62fba627-cceb-4a70-9740-322dfa27b2bc"), "Algeria", "2,381,740 Km²", 10, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a9f704fa-e064-4efa-9c1c-e6151f2464d1"), "Kazakhstan", "2,724,900 Km²", 9, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("42298e36-ab1a-44d8-8d8e-705325fe2a2c"), "Argentina", "2,780,400 Km²", 8, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2c83c976-2030-49e8-96af-c71f1c0c3c9c"), "India", "3,287,263 Km²", 7, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b9fc51d0-ff8b-4c7f-9b09-b519864d8aef"), "Australia", "7,741,220 Km²", 6, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bbb3de9d-e494-406e-a3ec-a25cb16547dd"), "Brazil", "8,515,770 Km²", 5, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("760ed086-9071-4ce0-9ab0-ce562b878f2e"), "China", "9,596,960 Km²", 4, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("17dce4ad-5e0a-445c-9bc8-ac7be1e6661c"), "United States", "9,833,517 Km²", 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("de323254-5f38-469a-b7ba-c300adb543d9"), "The United States", "9,833,517 Km²", 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("5d4711c6-c55f-4132-bfbc-75392910eab6"), "USA", "9,833,517 Km²", 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("56fc971e-df71-4a95-9a7d-c0c427329257"), "Canada", "9,984,670 Km²", 2, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("21eb2ad6-a1ce-49e9-8743-0ea9575d59ab"), "Russia", "145,934,462", 9, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("59c1fa07-fdc4-4d90-b11a-9832d289c889"), "Mexico", "128,932,753", 10, new Guid("00000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CategoryId",
                table: "Questions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
