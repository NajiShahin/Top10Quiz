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
                });

            migrationBuilder.CreateTable(
                name: "Answers",
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
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryQuestions",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryQuestions", x => new { x.CategoryId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_CategoryQuestions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryQuestions_Questions_QuestionId",
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
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000000"), "What are the biggest countries of the world" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000000"), "What countries have the biggest population" },
                    { new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613"), new Guid("00000000-0000-0000-0000-000000000000"), "What are the smallest countries of the world" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "ExtraInfo", "Points", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("4d7bd26f-0df3-4fae-9c9b-cd9e80620cca"), "Russia", "17,098,242 Km²", 1, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("aff37bf4-3e74-45ae-bd9b-0587421adbff"), "Bangladesh", "164,689,383", 8, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("e5a3d609-0a3f-4c1b-9cdb-5b82428bf83d"), "Russia", "145,934,462", 9, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("d4711d9b-2267-4be5-9ea9-4e118a23285b"), "Mexico", "128,932,753", 10, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("b2710771-e4ff-4970-9246-fd87c35945d0"), "Vatican", "0.49 Km²", 1, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("26ad01ed-ff4e-488a-8075-f38e0a53dd1c"), "Vatican City", "0.49 Km²", 1, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("61713893-8f93-45f8-b460-5c3acabdf6cb"), "Monaco", "2.02 Km²", 2, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("dfe9aefb-c6a5-4fd6-a8c8-d44e6916af2e"), "Nauru", "21 Km²", 3, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("ab751480-bf1c-4a85-8cd6-4f05de1de83a"), "Tuvalu", "26 Km²", 4, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("9bc60ddc-d231-40f8-9095-75cb975d232e"), "San Marino", "61 Km²", 5, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("6242f756-a1cf-4675-b812-0c99b6b908a6"), "Liechtenstein", "160 Km²", 6, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("df6458dc-ef68-4746-8e7f-504af7b25fc4"), "Marshall islands", "181 Km²", 7, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("f6fe9038-a13e-484e-b654-57c7b3331293"), "Saint kitts and nevis", "261 Km²", 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("e1af8ab0-2db9-4ff4-874a-8ad066db06d2"), "Saint kitts", "261 Km²", 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("afecdbde-30f8-4011-bd6d-19ef67612489"), "Saint nevis", "261 Km²", 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("ee38b690-23e4-4e06-964a-fca36a361ec9"), "kitts", "261 Km²", 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("7e0ffcff-4654-4757-aef0-a7a30cfd0cda"), "nevis", "261 Km²", 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("db50c390-b73b-45ac-b51c-2e16075f8c30"), "Maldives", "300 Km²", 9, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("9bd33f48-c741-42b1-b875-05b1e22f6be5"), "Nigeria", "206,139,589", 7, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("f43f0bf2-9c6b-4c46-903d-df0673156c43"), "Malta", "316 Km²", 10, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("a6fb5522-633a-4412-8176-6bd078f970fb"), "Brazil", "212,559,417", 6, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("3f0f4dc9-3d0e-4af8-8872-2aa221f82196"), "Indonesia", "273,523,615", 4, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("3831695c-cbfe-4d68-8a2a-e512dfcb4618"), "Canada", "9,984,670 Km²", 2, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fe7698c7-1c14-4095-adf1-bfcb3eb21ced"), "USA", "9,833,517 Km²", 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3b2fd177-28f0-4883-bc24-b3b93bdd7e6b"), "The United States", "9,833,517 Km²", 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("3c12adf3-8a34-4699-bb63-50738ec4b048"), "United States", "9,833,517 Km²", 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("065ef342-cc8a-49de-9527-a1f0674b26d0"), "China", "9,596,960 Km²", 4, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ba7b5c71-1963-4ee9-8b9b-03d3576c4ab2"), "Brazil", "8,515,770 Km²", 5, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c5732964-aad7-40d9-a017-fde583a5cd1f"), "Australia", "7,741,220 Km²", 6, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("6a4bf586-b178-4658-a49f-c3f32a00c27e"), "India", "3,287,263 Km²", 7, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("c9809f7a-683f-4367-87cc-13fc5d891ee9"), "Pakistan", "220,892,340", 5, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("89281623-75d7-4648-8120-fe425337fc64"), "Argentina", "2,780,400 Km²", 8, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("76811c12-224c-4f2e-9752-a4c9914aada6"), "Algeria", "2,381,740 Km²", 10, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("427131c5-27b8-4a08-a173-fa2870c78e43"), "China", "1,439,323,776", 1, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("b91d95dd-8c75-4394-8ce0-4aab8a073896"), "India", "1,380,004,385", 2, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("88fd8d65-6828-4638-8640-c59ecd65aaec"), "USA", "331,002,651", 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("c3f96744-6217-4754-813b-489e2f99131e"), "The United States", "331,002,651", 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("4d99a88a-64f1-4f85-9bb2-f0c6b8b34238"), "United States", "331,002,651", 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("aa528fb6-860c-4157-be50-a2f8b1b2d522"), "Kazakhstan", "2,724,900 Km²", 9, new Guid("00000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "CategoryQuestions",
                columns: new[] { "CategoryId", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryQuestions_QuestionId",
                table: "CategoryQuestions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "CategoryQuestions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
