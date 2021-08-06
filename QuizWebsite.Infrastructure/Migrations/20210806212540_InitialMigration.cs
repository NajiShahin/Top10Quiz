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
                    QuestionType = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false),
                    Dislikes = table.Column<int>(nullable: false),
                    DateTimeChanged = table.Column<DateTime>(nullable: false),
                    ChangeFrequency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Public = table.Column<bool>(nullable: false),
                    QuestionAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ConnectionId = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Ready = table.Column<bool>(nullable: false),
                    ColorCode = table.Column<string>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomQuestions",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false),
                    activeQuestion = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomQuestions", x => new { x.RoomId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_RoomQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomQuestions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-100000000001"), "Countries" },
                    { new Guid("00000000-0000-0000-f000-900000000007"), "History" },
                    { new Guid("00000000-1001-1001-1001-500000100005"), "People" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "ChangeFrequency", "DateTimeChanged", "Dislikes", "Likes", "QuestionText", "QuestionType" },
                values: new object[,]
                {
                    { new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3666), 0, 0, "Countries with most homicides per 100,000 people", "Top 10" },
                    { new Guid("f5b97548-cb81-44b5-8830-aba39f71c079"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3670), 0, 0, "What are the countries with the highest murder count per year", "Top 10" },
                    { new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3675), 0, 0, "What countries have the highest fertility rate (2019)", "Top 10" },
                    { new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3679), 0, 0, "What countries have the lowest fertility rate (2019)", "Top 10" },
                    { new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3683), 0, 0, "What countries have won the most gold medals at the olympics", "Top 10" },
                    { new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3688), 0, 0, "What countries have the most amount of total immigrants", "Top 10" },
                    { new Guid("03744a50-cdd5-43c1-898d-b69df8168820"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3692), 0, 0, "What countries have the most percentage of immigrants", "Top 10" },
                    { new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3697), 0, 0, "What are the countries that drink the most beer per capita", "Top 10" },
                    { new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82"), 4, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3701), 0, 0, "What are the countries with the most unesco world heritage sites", "Top 10" },
                    { new Guid("94e5f344-ef61-44c6-b209-9b805ca42880"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3705), 0, 0, "What are the most visited countries in the world (2019)", "Top 10" },
                    { new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b"), 2, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3709), 0, 0, "What countries have the most billionaires (2021)", "Top 10" },
                    { new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291"), 2, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3714), 0, 0, "What countries have the most millionaires (2021)", "Top 10" },
                    { new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3662), 0, 0, "What are the countries with the oldest median age (2020)", "Top 10" },
                    { new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3658), 0, 0, "What are the countries with the youngest median age (2020)", "Top 10" },
                    { new Guid("00437064-4748-470c-b77e-046703a2a19a"), 6, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3653), 0, 0, "What are the newest countries in the world", "Top 10" },
                    { new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae"), 6, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3647), 0, 0, "What are the first countries if you order them alphabetically (A-Z)", "Top 10" },
                    { new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3642), 0, 0, "What are the most obese countries of the world (2016)", "Top 10" },
                    { new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3638), 0, 0, "Which countries spend the most on their military", "Top 10" },
                    { new Guid("5a563a77-0a11-459a-8162-d886acf1f898"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3633), 0, 0, "What are the least happiest countries (according to the World Happiness Report in 2020)", "Top 10" },
                    { new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3629), 0, 0, "What countries have the highest prison population", "Top 10" },
                    { new Guid("26775c7d-97ea-415d-b73c-7629759656cf"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3624), 0, 0, "What countries have the highest GDP per capita", "Top 10" },
                    { new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3620), 0, 0, "What countries have the highest GDP (nominal)", "Top 10" },
                    { new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3615), 0, 0, "What countries have the biggest population of catholics", "Top 10" },
                    { new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3611), 0, 0, "What countries have the biggest population of muslims", "Top 10" },
                    { new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2"), 3, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3606), 0, 0, "What are the happiest countries (according to the World Happiness Report in 2020)", "Top 10" },
                    { new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613"), 6, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3598), 0, 0, "What are the smallest countries of the world", "Top 10" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 4, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3531), 0, 0, "What countries have the biggest population", "Top 10" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), 6, new DateTime(2021, 8, 6, 23, 25, 39, 837, DateTimeKind.Local).AddTicks(6946), 0, 0, "What are the biggest countries of the world", "Top 10" },
                    { new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b"), 6, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3719), 0, 0, "Who were the first ten presidents of the United States", "Top 10" },
                    { new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13"), 5, new DateTime(2021, 8, 6, 23, 25, 39, 840, DateTimeKind.Local).AddTicks(3723), 0, 0, "Who were the last ten presidents of the United States", "Top 10" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "ExtraInfo", "Place", "Points", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("2dc3dcd0-198f-411f-9740-8fd708d3c7bb"), "Russia", "17,098,242 Km²", 1, 1, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2566c4cb-8a98-451e-98a1-1275bbced23e"), "Vatican", "100%", 1, 1, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("a5c1fc15-4529-4aa9-af48-503f3956f93a"), "Vatican City", "100%", 1, 1, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("f57577aa-1c95-4d0b-b247-96c8e0e9a86a"), "Holy See", "100%", 1, 1, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("8bef0d32-e2aa-42cb-b070-cda9716cdeb4"), "Italy", "6,273,722", 10, 10, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("c007d748-7d4c-4c9f-bff6-dbf213a3013e"), "Australia", "7,500,000", 9, 9, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("0c3f402d-3469-44db-b15a-423bdea88ca8"), "Canada", "8,000,000", 8, 8, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("a404388d-3f38-461e-9842-7851a7a04e67"), "France", "8,300,000", 7, 7, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("666f02d3-86c0-45f0-80c3-0cccf9073dfd"), "UAE", "8,600,000", 6, 6, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("c26ca33f-b864-4283-9bd3-b4f8b3fb31e7"), "United Arab Emirates", "8,600,000", 6, 6, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("3aa6adcb-e031-46a7-bbe8-c166ce68eff6"), "UK", "9,600,000", 5, 5, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("ca8665cc-a686-4e7e-b2dc-c712d5a17f18"), "United Kingdom", "9,600,000", 5, 5, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("b8779747-4115-4fd1-9644-5b310c064b0a"), "Russia", "11,600,000", 4, 4, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("1d47e0ec-475b-4daf-9300-fd4fef38e7b9"), "Saudi Arabia", "13,100,000", 3, 3, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("0566832a-400a-4c29-94cb-c9a30a5e2d1a"), "Germany", "13,100,000", 2, 2, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("ee3dd4d6-f219-4913-83d9-11853bb234af"), "USA", "50,700,000", 1, 1, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("43c3f59f-9ebb-4f48-b922-505fa4fcc181"), "US", "50,700,000", 1, 1, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("8a1efd85-1d7d-432e-8da8-db27617fec1e"), "United states", "50,700,000", 1, 1, new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("43691707-5073-4c15-9ad3-1d414cf3873e"), "Sweden", "145", 10, 10, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("a97ae551-1874-4894-aa09-2ab7a357dda3"), "Australia", "147", 9, 9, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("90e701ac-671c-4b81-bcf6-8fc03b217d30"), "Hungary", "175", 8, 8, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("41c16a69-d2a1-462e-ac66-3382e8d661cc"), "Italy", "206", 7, 7, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("bc2e7f08-4104-4f32-9360-257c2178d9c7"), "France", "212", 6, 6, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("8dde02f4-53c5-41b4-8b87-1bca802048d9"), "Chin", "224", 5, 5, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("e250091c-b072-4a16-9c7f-a439f644aa0e"), "UAE", "87.9%", 2, 2, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("00390daa-ea1e-4c99-9c73-b9fb739d6d25"), "United Arab Emirates", "87.9%", 2, 2, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("3b30200c-3f47-40f8-b1d5-26b280de026e"), "Qatar", "78.7%", 3, 3, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("2d303ec7-006a-4525-b4c2-bdcefc3a1596"), "Kuwait", "72.1%", 4, 4, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("8d446e4a-4624-4949-882b-eb47a52f0c5d"), "Mexico", "35", 7, 7, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("7efdb539-f727-4002-87bd-292a8a459bc4"), "India", "38", 6, 6, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("dce6f39b-490d-45f6-a09f-15ee1107f814"), "France", "45", 5, 5, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("0fae628f-5be1-4cf9-a698-001360666384"), "Germany", "46", 4, 4, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("1e72f6ad-fe9c-4322-9e60-f6ba3c63e904"), "Spain", "48", 3, 3, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("714de6a9-54ab-4a19-8c98-adee5a11302d"), "China", "55", 2, 2, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("1a594626-babe-454a-acb9-a225e800a3a2"), "Italy", "55", 1, 2, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("501eb8f2-7bd5-4b9f-a485-5b644f98e047"), "Lithuania", "88.7 liters", 10, 10, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("45b1aef9-12cc-4804-bd66-d6310e274396"), "Estonia", "89.5 liters", 9, 9, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("da767135-e056-4665-b2dc-ac701f6ac298"), "Seychelles", "90 liters", 8, 8, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("e89dd155-6f71-4d37-8166-9602e7c08f59"), "Romania", "94.1 liters", 7, 7, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("fb4548c3-230e-43b7-bf23-77077956b950"), "Great Britain", "263", 4, 4, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("4064e0ce-a742-48f1-907d-945e577d3965"), "Ireland", "98.2 liters", 6, 6, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("5d59c134-23a8-4cef-92c4-751c710ab551"), "Germany", "104.2 liters", 4, 4, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("6e6c1b23-aeaa-4974-80bf-9b7419f0ff7c"), "Austria", "106 liters", 3, 3, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("0bdffb05-52d4-4a33-822e-585b825d1480"), "Namibia", "108 liters", 2, 2, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("dd061e14-86fa-43aa-b4ff-429b74265f9b"), "Czech Republic", "143.3 liters", 1, 1, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("48ddba84-9d64-45d0-b86f-465caf7663b4"), "Czechia", "143.3 liters", 1, 1, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("38ccaacc-2507-4aa8-a1d0-08eaa4fda739"), "Bahrain", "46.0%", 10, 10, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("6ddb56ea-ddd1-446c-961b-5f13e5c254f7"), "Oman", "47.4%", 9, 9, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("ee21f4ec-fb3a-42d2-a9ee-6d8d32fc27f0"), "Luxembourg", "47.4%", 8, 8, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("2642e150-509b-4b87-9b10-3593826a9478"), "Andorra", "58.5%", 7, 7, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("a32f6b37-cadb-4de7-8618-0f1cdd3a4226"), "Liechtenstein", "67.0%", 6, 6, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("3dcae26e-99f5-415a-b6b6-cf3466951aa3"), "Monaco", "68.0%", 5, 5, new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("8b89a7a1-9be8-42aa-997e-a30453c0f0b3"), "Poland", "100.8 liters", 5, 5, new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("3d0fab4a-eaac-4504-b113-fdfff12af3ac"), "UK", "263", 4, 4, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("14a1abbc-fd81-488d-baf3-b8ff8e3ee630"), "United Kingdom", "263", 4, 4, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("ae0a2109-cc1b-4e78-a0c9-6c770d542328"), "Germany", "428", 3, 3, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("d97bd357-a407-4a0c-938a-ed3360ba0aa0"), "Democratic Republic of the Congo", "5.819", 3, 3, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("abd76d68-1532-43d4-9933-487c34a38700"), "Congo", "5.819", 3, 3, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("58118199-7728-4f8a-9776-71854c499dd3"), "DRC", "5.819", 3, 3, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("afee021d-920f-43f9-ad86-fb931060dbd6"), "Somalia", "5.978", 2, 2, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("c76945ee-791e-4b8b-bbe3-e55d05aef5c7"), "Niger", "6.824", 1, 1, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("c020b5cf-41cb-4134-b449-6fd5cd732ffa"), "Democratic Republic Congo", "10,322", 10, 10, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("2b41df46-b45d-49fe-86ea-6658a69b3867"), "Republic Congo", "10,322", 10, 10, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("aef151ff-fc17-4834-a2ae-af765fcbc515"), "DR Congo", "10,322", 10, 10, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("d9a3bc9b-32ab-4f72-adeb-5fbe578ae1a5"), "Democratic Republic of the Congo", "10,322", 10, 10, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("2853337b-d362-412b-8b28-e4232bb08269"), "Congo", "10,322", 10, 10, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("4b45e2bb-a955-473d-82d5-df6ba9dc32ee"), "DRC", "10,322", 10, 10, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("f2e344ea-1c90-40c9-97c0-d7024657e2bb"), "DR Congo", "5.819", 3, 3, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("0dda814f-4df6-45ff-9d25-f49ac254b1c0"), "Venezuela", "10,598", 9, 9, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("ccf1b216-2976-40f0-8bf8-1b01ad42fe4a"), "Colombia", "12,586", 7, 7, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("1df063d7-bba0-4b52-9363-f014dbc84540"), "US", "16,214", 6, 6, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("d0329cb9-7a86-41d1-8aca-9f7a5fe95722"), "USA", "16,214", 6, 6, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("849ff016-1944-4ff6-ab09-1b86d2685a12"), "United States", "16,214", 6, 6, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("d6cd6880-1bb9-4bf8-a9c6-5b6373e0347e"), "Nigeria", "17,843", 5, 5, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("5720a018-951f-4c82-a7d1-c168eaa06af8"), "South Africa", "21,036", 4, 4, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("c7c7f863-079a-49df-8541-571d08a5ede4"), "Mexico", "36,685", 3, 3, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("4c379677-64a1-4a3e-be0a-327f4cefee0c"), "Brazil", "57,358", 1, 1, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("e2765858-1b6e-45d4-9893-da8e0d9febff"), "Bahamas", "30.90", 10, 10, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("4cef83e8-35ab-45a0-9e20-07b931f6d567"), "Nevis", "34.23", 9, 9, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("f4443982-2f9a-4aa9-a4d3-0820e487bd01"), "Saint Kitts and Nevis", "34.23", 9, 9, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("5b2cd4f1-37d3-49e1-97ec-8d283c75f8ae"), "Russia", "11,964", 8, 8, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("6d74cd11-c09e-42d3-8d52-72affdef112d"), "United Kingdom", "32", 8, 8, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("a1facf98-60ec-4927-a596-b6f54e142b1d"), "Republic Congo", "5.819", 3, 3, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("83bb1fce-842a-4ada-bdfe-bdba01aae6a5"), "Mali", "5.785", 4, 4, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("9eb8978f-84f3-4cc9-8aa8-2a2d178a1202"), "USSR", "544", 2, 2, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("17b9bf74-2c72-4da6-a1e0-6f5d70c240a9"), "Russia", "544", 2, 2, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("f0e2c3cd-39d6-41b6-8d21-5cbd3acbd70d"), "Soviet union", "544", 2, 2, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("297452cf-bbaa-43dd-96e1-aa6b208ae2e9"), "US", "1022", 1, 1, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("4f8f5230-05d4-483c-8a37-752acde618fe"), "USA", "1022", 1, 1, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("50e20bbf-eafd-4d33-858e-d746086af773"), "United States", "1022", 1, 1, new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("64d28950-935b-4499-bb1f-23c54372598d"), "Luxembourg", "1.340", 10, 10, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("acbdffd2-c729-4506-9bbd-ebaa20dc29d8"), "Cyprus", "1.321", 9, 9, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("63bb18cb-bf42-4065-9b73-13fbc52c09f4"), "Italy", "1.270", 8, 8, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("fc7fe7ef-2329-4eed-a2fe-22ae3b6fd7da"), "Moldova", "1.269", 7, 7, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("f19a2038-a46a-4a05-8e28-3da166b151e2"), "Herzegovina", "1.254", 6, 6, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("4c370619-cb11-4696-9b23-9cd156e0a487"), "Democratic Republic Congo", "5.819", 3, 3, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("58512636-559d-4ba0-bc9c-382bcf86e3b9"), "Bosnia ", "1.254", 6, 6, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("dd0ebb66-22d2-4225-9b06-2d4d55a29795"), "Spain", "1.240", 5, 5, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("a8ade582-2255-43eb-8fe0-330e64305a4a"), "Ukraine", "1.228", 4, 4, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("c8d0c651-f154-4dc4-a06a-298795c204d0"), "Singapore", "1.140", 3, 3, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("71a3cb4e-e3fd-4be7-9295-a6232f354113"), "Malta", "1.100", 2, 2, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("ad8e8053-39f1-456d-9550-c4d93055ef44"), "South Korea", "0.864", 1, 1, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("2da37466-76bc-47c3-9a2e-c9d602c24b32"), "Burkina Faso", "5.109", 10, 10, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("4eb7fba9-2b80-4d06-8c14-46e5df10fe35"), "Gambia", "5.154", 9, 9, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("084fa2aa-9619-4f80-91aa-70593eb89c6e"), "Nigeria", "5.317", 8, 8, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("8038b4c3-17b2-4492-a2aa-3554614f659c"), "Burundi", "5.321", 7, 7, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("6e609dcf-518d-47a4-9b36-fc941e911320"), "Angola", "5.442", 6, 6, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("ddaf8fbc-588c-424e-a685-0ea2f91deaf7"), "Chad", "5.649", 5, 5, new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("3462e894-d5d3-400b-985a-1d2114d86fcc"), "Bosnia and Herzegovina", "1.254", 6, 6, new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("420b96fc-8a54-4b2d-8e5d-1df6e3000a95"), "South Africa", "36.40", 8, 8, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("f1c11fd6-3fef-4d6e-b899-b0f79835b884"), "UK", "32", 8, 8, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("1d02ec78-2ce1-4a15-ba76-96f37e7cfb33"), "United States", "24", 10, 10, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("f936df08-7f54-48d1-a39d-ef62db31c75a"), "Joe", "", 1, 1, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("5cf08d9a-4b29-42c6-8c74-1df9ba7662ac"), "Joe Biden", "", 1, 1, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("c8685809-5699-4b16-bb22-131b14683e30"), "Tyler", "", 10, 10, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("aa3e23e7-b2cd-496a-b8cc-7f806f41d867"), "John", "", 10, 10, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("d6702263-bebf-42fe-8174-4b66ca8882b4"), "John Tyler", "", 10, 10, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("e68a3aaf-4938-48bc-97e0-46ff918ac19f"), "William H Harrison", "", 9, 9, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("f175d48c-59c6-444a-91c1-4d68516e1940"), "Harrison", "", 9, 9, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("bb68795b-1bb6-4500-ba92-ad1681283868"), "Henry", "", 9, 9, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("3ba56ff5-ec21-4046-a102-c484246d0566"), "William", "", 9, 9, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("9416206f-4983-4bba-93ee-a26ff1eb279a"), "Wiliam Henry Harrison", "", 9, 9, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("a7de26c5-0a48-48fe-bc0c-9650262d10e4"), "Van Buren", "", 8, 8, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("f038107c-3674-4639-969a-b327eff3d5b5"), "Martin", "", 8, 8, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("6350c3ad-cb15-4c6e-9b97-73c35fbb9fd2"), "Martin Van Buren", "", 8, 8, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("e763a728-7bc7-458d-acd6-4861245f3486"), "Jackson", "", 7, 7, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("2106719a-01a2-4c00-8642-b8b87937be93"), "Andrew", "", 7, 7, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("b312bcd5-5d2c-4207-8c9e-b49555635878"), "Andrew Jackson", "", 7, 7, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("75a0677a-1dee-4df1-a7e2-d71ace8c3abf"), "John Q Adams", "", 6, 6, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("1b84d497-83c9-41ff-a373-a98cf9d8242c"), "Adams", "", 6, 6, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("4c5ab592-e14b-41fb-9a2a-3d418158ae50"), "Quincy", "", 6, 6, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("9d91836b-dab4-4ff8-af4c-40f5bfa04192"), "John", "", 6, 6, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("d2efff2b-5e72-4745-94b6-3a32e21d70f5"), "John Quincy Adams", "", 6, 6, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("5d4549af-5fb3-4e3b-9dcc-39c2b35e3c91"), "Monroe", "", 5, 5, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("1cdaf6f5-15c6-4188-ac19-00c95c059010"), "James", "", 5, 5, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("bd473459-3b04-476b-b455-1b28b7499db1"), "Biden", "", 1, 1, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("204be055-f55c-4754-9cda-71bf878f144d"), "Donald Trump", "", 2, 2, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("a8aba7f3-42f7-4afd-ab08-217582642255"), "Donald", "", 2, 2, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("a14ee43f-2f30-4d6e-bd76-d5ac33f91233"), "Trump", "", 2, 2, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("afbc127a-0d18-4ef5-916e-b023d62936c5"), "Nixon", "", 10, 10, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("dab53230-336b-4826-bdd9-4b47d9b1073d"), "Richard", "", 10, 10, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("bc66300c-cd3e-467f-b60a-cdcc6ad0ac89"), "Richard Nixon", "", 10, 10, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("a952a3b8-4c40-4b2f-b29c-d43350aef08e"), "Gerald Ford", "", 9, 9, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("5f43a6b2-e004-43e3-85d6-ed2b58c9d55c"), "Ford", "", 9, 9, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("694c5919-bd11-4da1-a263-a2120f143ead"), "Gerald", "", 9, 9, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("85af9cf8-8bce-4325-8d19-1f2eaab19dec"), "Carter", "", 8, 8, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("51b6338c-9f78-428c-8e10-75e3e785e7c2"), "Jimmy", "", 8, 8, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("bf51e484-5b65-4d94-b839-fbb6f773cd92"), "Jimmy Carter", "", 8, 8, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("90678433-5a10-47f0-a685-79d1b40d8838"), "Reagan", "", 7, 7, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("deda491a-c1a7-4bc4-9aae-473b9600a56c"), "Ronald", "", 7, 7, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("f42e19de-a49c-42b5-9549-bcadd897d04b"), "James Monroe", "", 5, 5, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("000a8aa7-3b00-431b-ab1c-8e0631ad570e"), "Ronald Reagan", "", 7, 7, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("c8e44155-2854-4101-a94b-52daf26b2e8b"), "George", "", 6, 6, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("fecfb305-b9a3-4536-9280-9c0584cab3fa"), "George H. W. Bush", "", 6, 6, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("488a6184-83c4-4e91-b4c2-7a934ae0aaf7"), "Clinton", "", 5, 5, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("5ff14b67-22d6-4b55-a491-180f880665e1"), "Bill", "", 5, 5, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("f49aae66-85da-4ea1-8de7-0cc13d4e35f1"), "Bill Clinton", "", 5, 5, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("328e3769-93f4-4cb6-981e-080a600a7026"), "Bush", "", 4, 4, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("b75c2d11-f75b-4031-b860-080bb8389477"), "George", "", 4, 4, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("88e7e916-46b8-4498-ab30-e24f7f145c7f"), "George W. Bush", "", 4, 4, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("94097ca7-b21b-4da9-a395-28ce1f441ac1"), "Obama", "", 3, 3, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("f8a24985-db9e-49ed-90bb-5bb8dbbb6979"), "Barack", "", 3, 3, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("b107fb6c-6598-487c-a21b-56ee882fc0a3"), "Barack Obama", "", 3, 3, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("5461e52a-d0f3-4a71-9821-33247d747f48"), "Bush", "", 6, 6, new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("5c184be2-02d0-4bab-831f-0a85662f73d6"), "Madison", "", 4, 4, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("9a64606a-1c92-422e-bd28-336e916eddde"), "James", "", 4, 4, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("85f55970-2982-4716-97c6-0f1610c2a3f9"), "James Madison", "", 4, 4, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("956e60ca-b237-4849-be6d-a11b00c7446e"), "Russia", "117", 5, 5, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("ab5a0746-0932-466e-9bb0-291fce32f7cd"), "Germany", "136", 4, 4, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("670c80f9-4f3b-4c0a-a335-af0d722d845d"), "India", "177", 3, 3, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("d8537d35-bfd2-457b-953a-c88dc76878dd"), "China", "698", 2, 2, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("4b94c070-6ea1-48ae-8ba0-e2b902958f56"), "US", "724", 1, 1, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("cb1b9835-dc8f-4d3a-a165-42996d17710e"), "USA", "724", 1, 1, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("efbb6746-f0b8-43d7-95e3-baa4a69ab088"), "United States", "724", 1, 1, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("c209959e-79bc-4142-b183-1748aa2a4136"), "UK", "39,400,000", 10, 10, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("355b6b79-ea86-4895-b0ff-4592ec808ed8"), "United Kingdom", "39,400,000", 10, 10, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("433be202-6e63-4c57-b182-c6fbec5c2505"), "Germany", "39,600,000", 9, 9, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("31a161da-2bbd-47b0-b2f2-376bfa2d24ba"), "Thailand", "39,800,000", 8, 8, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("b78259c9-4651-4016-bff8-ffdf0bc201a1"), "Brazil", "65", 6, 6, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("67631141-d815-4db2-bb91-9b414df322da"), "Mexico", "45,000,000", 7, 7, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("98f3a511-a9dc-408b-9572-d0b8e6c46388"), "Italy", "64,500,000", 5, 5, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("f9aa76e0-3238-4d54-8e57-68abef23da93"), "China", "64,700,000", 4, 4, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("091bbd99-2750-4f49-8e1a-9a9319d47a5d"), "USA", "79,300,000", 3, 3, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("99138389-6a3d-4a45-813c-34979d63cba3"), "US", "79,300,000", 3, 3, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("44631498-ba2c-4a63-9e04-387db00ecc4e"), "United States", "79,300,000", 3, 3, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("7cc6b771-3305-4af9-a3ac-6846167109b3"), "Spain", "83,500,000", 2, 2, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("d032b782-eb18-4468-b5dc-7ad05df54236"), "France", "", 1, 1, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("9a8eac45-ad2a-41cd-bef4-5e5129bdd9e5"), "United States and Iran", "24", 10, 10, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("151897e0-448b-42b9-9c25-6f8b0f33637d"), "Iran", "24", 10, 10, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("b8ae7a31-87e5-42a9-adb8-23c73436231a"), "US", "24", 10, 10, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("ff9d56e6-eda3-405e-aef2-af948812f6ce"), "USA", "24", 10, 10, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("da0b325a-1a74-4545-be90-d953dc0f447a"), "Turkey", "51,200,000", 6, 6, new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("ed5402d4-1220-4c4d-8da5-783d42d695e6"), "Russia", "29", 9, 9, new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("933ad30e-6af9-49bc-a198-54ee31bb8052"), "Canada", "64", 7, 7, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("366cd954-1412-48d8-931a-d7e074c96f45"), "UK", "56", 8, 8, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("5485697c-8b81-41ad-ab6c-4894aae75cbe"), "Jefferson", "", 3, 3, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("7aab781b-ff86-4233-b6c4-db163670441f"), "Thomas", "", 3, 3, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("c618e33f-1a41-4b6b-b153-9cc980cc382e"), "Thomas Jefferson", "", 3, 3, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("3569f6b3-6f96-4000-a40e-b11b4749846f"), "Adams", "", 2, 2, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("ac4d603b-d4b6-4b26-a7df-22f037b3efd2"), "John", "", 2, 2, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("d08627b0-28e9-4dce-b06f-a36c9a892f9e"), "John Adams", "", 2, 2, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("9aef2da7-bbeb-492e-b89b-fefa18e908dd"), "Washington", "", 1, 1, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("d3f9f1b1-c3cc-478e-9e9b-ae186b4c36ca"), "George", "", 1, 1, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("35feb675-ceb0-4327-882a-fbc37781e067"), "George Washington", "", 1, 1, new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("055b21ea-6a37-46aa-bb75-9ab886d705ba"), "Spain", "1,146,911", 10, 10, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("bc78b9f9-3dd8-4617-8ef7-a6f9da03e1ec"), "Italy", "1,479,830", 9, 9, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("059d6da6-cf11-4a06-aa8b-f2d27d279d4f"), "United Kingdom", "56", 8, 8, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("d62cbb72-909f-44eb-9836-88908e92e1c0"), "Canada", "1,681,969", 8, 8, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("1f64cbae-691c-404a-a67f-86ded93189d2"), "France", "2,468,939", 6, 6, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("2a3fba24-de09-47b1-9cbf-12853b0bd8e9"), "UK", "2,490,952", 5, 5, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("2508c9b8-c65e-487a-b283-4f4891509351"), "United Kingdom", "2,490,952", 5, 5, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("8f2f8e7e-aab8-435b-90ba-98f408c55ad2"), "Germany", "2,952,710", 4, 4, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("1b35ee6f-c03c-4590-b31e-db1c1e85f766"), "Japan", "3,662,407", 3, 3, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("e9b159bf-98ec-421f-87d1-8fdae51dda88"), "China", "5,279,467", 2, 2, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("3878a0e9-c255-4fb5-9716-4964e7620135"), "USA", "21,951,202", 1, 1, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("768f58ab-e13a-425a-9fdb-b6ed9116000b"), "US", "21,951,202", 1, 1, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("1b95b5e9-9b62-4560-b714-e1d2d2ca6084"), "United States", "21,951,202", 1, 1, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("b1b0d583-6093-41e6-884c-ca4357a96f7e"), "Japan", "49", 10, 10, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("8124299b-9f62-446c-b05c-a011f170a06a"), "Italy", "51", 9, 9, new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("24012389-5e16-4a20-a7ce-a15b32725d86"), "Australia", "1,804,644", 7, 7, new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("0e9f54e9-f324-46de-9e29-1f3b6c456b11"), "The Grenadines ", "36.69", 7, 7, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("b3fbdd51-1e96-4f82-995e-1f1f5da3155c"), "India", "41,651", 2, 2, new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("47b7100e-ef7a-4a42-83d1-be03c6faa6e0"), "Saint Vincent and the Grenadines", "36.69", 7, 7, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("239422af-6ec4-4e92-b0ea-0c5174bdc2ec"), "UK", "$3,124,650", 5, 5, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("4ca33e6e-cc27-4183-a689-0385031914bb"), "The united kingdom", "$3,124,650", 5, 5, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("4ca33e6e-cc27-4183-a689-03850319b4bb"), "United kingdom", "$3,124,650", 5, 5, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("c781c5bc-f7c5-45ed-ba21-e83040d1d8b1"), "Germany", "$4,319,286", 4, 4, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("87c16cc0-67c1-41b4-b32b-3922c7e42876"), "Japan", "$5,378,136", 3, 3, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("732dc497-5471-4004-9134-52bffc30f9df"), "China", "$16,642,318", 2, 2, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("44b3e676-296d-4ebb-b037-8c6964c96c6b"), "US", "$22,675,271", 1, 1, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("7bb745ca-5baa-4118-87b6-193a5308eca0"), "USA", "$22,675,271", 1, 1, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("b396c03a-4b5a-4fd2-9da3-cc05fae357e6"), "United states", "$22,675,271", 1, 1, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("0fb8babc-686a-4cdf-af19-46d2d50d0e36"), "Argentina", "28,770,000", 10, 10, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("deea636a-45d4-4fca-8ab5-6eea5882ebc5"), "Spain", "30,720,000", 9, 9, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("ace69a94-b738-4f9b-9904-9b74c5dc4ebd"), "Poland", "33,037,017", 8, 8, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("9bcb8bc6-ab0f-495d-b76f-67538ac3be2a"), "Colombia", "35,000,000", 7, 7, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("547ba9a6-4470-4d12-bf36-982ea49ca310"), "France", "39,000,000", 6, 6, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("3f03a8db-e399-41f0-b5a1-d93dd3c399a4"), "Italy", "50,474,000", 5, 5, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("05c85253-6a3c-4949-b917-33690c555c76"), "US", "69,300,000", 4, 4, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("fc6f3fb4-2c0d-4dfc-97ef-bda659584b5d"), "United states", "69,300,000", 4, 4, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("68ac305f-599c-4fe8-9c38-c1ca3f14e32f"), "USA", "69,300,000", 4, 4, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("7e59b3fd-a9d2-4221-a191-eadb590c4979"), "Philippines", "85,470,000", 3, 3, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("03638695-666d-4c65-b34a-1016d1fb21aa"), "Mexico", "100,000,000", 2, 2, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("7560a37e-f163-403d-897d-5c2b747cb13e"), "Brazil", "123,360,000", 1, 1, new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("e5df616b-d005-4e1f-a692-41390ac81b81"), "Sudan", "39,585,777", 10, 10, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("0791ca0e-8ae0-4584-9dd7-02dee5b843ec"), "Algeria", "41,240,913", 9, 9, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("819e278b-8f0e-41f9-ab3a-2e9efbfbb4f2"), "India", "$3,049,704", 6, 6, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("5400b45a-82dd-434a-8c18-b6d30eb2fbac"), "France", "$2,938,271", 7, 7, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("ce9178ef-f3ea-43d4-a4f9-018943351399"), "Italy", "$2,106,287", 8, 8, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("261e1239-de34-4cf1-bfce-3e91b6d63103"), "Canada", "$1,883,487", 9, 9, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("a784845b-ab59-4b6c-be29-c8aa47087de9"), "Philippines", "215,000", 9, 9, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("19c36694-151b-411d-b2f4-8057bba56e46"), "Iran", "240,000", 8, 8, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("2d08a2aa-5889-45e6-9298-ba1dc0755952"), "Turkey", "286,000", 7, 7, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("fc9db92e-0240-47dc-a308-2e86c32ab781"), "Thailand", "375,148", 6, 6, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("2dd69c2a-5b8c-49b6-9ac1-45989955ceee"), "Saint Vincent", "36.69", 7, 7, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("f6617940-0e48-40e6-b5a4-2df51d902d4a"), "Russia", "511,030", 4, 4, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("f8df59e5-c060-41d9-88a2-868d06efd2b9"), "Brazil", "773,151", 3, 3, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("527293e7-d9fd-416a-9d90-4d64b493fc3b"), "China", "1,710,000", 2, 2, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("1e82c829-a73c-428f-91d4-92c898beca64"), "US", "2,121,600", 1, 1, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("b2f30d8f-5b1a-43b0-8866-87909ff653c4"), "United states", "2,121,600", 1, 1, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("eda6e78f-d69b-4038-ae72-46351bf27c87"), "USA", "2,121,600", 1, 1, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("1479cdf7-15e6-434e-87c2-f8c4e9482a02"), "Turkey", "74,423,725", 8, 8, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("7a1e706c-47ec-4ef0-a9d9-b9bad3b961bc"), "Singapore", "", 10, 10, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("3da04baf-7958-4f4f-bda7-3983c14c2bbd"), "Iceland", "", 8, 8, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("edd78977-5121-41d5-8aff-120c8a07c633"), "US", "", 7, 7, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("28e3e678-c880-44c9-9a96-b26ed524c834"), "USA", "", 7, 7, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("eba8c8fd-8e51-4d17-a3fb-001e792acd9b"), "United states", "", 7, 7, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("43ad001c-abb0-4319-8041-47e5594cd16a"), "Norway", "", 6, 6, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("2adb1d9b-4fb3-4a23-b262-11069c7f2672"), "Ireland", "", 5, 5, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("04daef47-7763-4faf-b7b1-5e7860e99577"), "Switzerland", "", 4, 4, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("506325f1-b3a8-4eaf-9caf-a9011484dcbb"), "Luxembourg", "", 3, 3, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("25afec51-f853-4df7-bcad-e7a88f576746"), "Liechtenstein", "", 2, 2, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("1bf35cab-2cc3-49cf-b0f3-eca70711b91f"), "Monaco", "", 1, 1, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("ca306b3b-5854-4f23-8978-b60ec8e7048c"), "South korea", "$1,806,707", 10, 10, new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("0391dfd8-28fc-482f-a10d-b8e0c0d066cf"), "Denmark", "", 9, 9, new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("1e5b5d1a-49b1-4508-8fde-2a07515093fb"), "Iran", "82,500,000", 7, 7, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("6198d886-ca83-4528-a69b-43d6507f0dd8"), "Egypt", "90,000,000", 6, 6, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("661ce531-3921-47fd-ad59-b70ff7868d36"), "Nigeria", "103,000,000", 5, 5, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("b2710771-e4ff-4970-9246-fd87c35945d0"), "Vatican", "0.49 Km²", 1, 1, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("29f990f0-d541-4638-bb3c-6f0e5d9b07f5"), "Mexico", "128,932,753", 10, 10, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("68e8a9cc-97ae-45f4-a4ca-26e9ddf43575"), "Russia", "145,934,462", 9, 9, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("a623e5bf-a6c8-4bc6-a5f6-e0c8087fe6a1"), "Bangladesh", "164,689,383", 8, 8, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("7cec9cdb-d8ae-44cc-8673-5af06ff7c6d6"), "Nigeria", "206,139,589", 7, 7, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("dddbcebd-6d41-48b6-a1cd-51bde8e45131"), "Brazil", "212,559,417", 6, 6, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("78be3a9b-356d-4968-9b75-daa6ef88ff45"), "Pakistan", "220,892,340", 5, 5, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("cd896068-8620-4afd-baab-395289086618"), "Indonesia", "273,523,615", 4, 4, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("55305250-92af-4eab-8d33-a93eb9cf7ca7"), "United States", "331,002,651", 3, 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("4db9bfbc-d8ee-4004-8a13-40e8ef11cfd7"), "US", "331,002,651", 3, 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("90a3ed1e-88df-4ec3-84df-c0b04addb575"), "USA", "331,002,651", 3, 3, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("26ad01ed-ff4e-488a-8075-f38e0a53dd1c"), "Vatican City", "0.49 Km²", 1, 1, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("bb95c8d7-9f84-427c-b023-18c5acc1cc4c"), "India", "1,380,004,385", 2, 2, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("ddfb4b9e-3894-4cb0-9ea6-1240f53cfe8a"), "Algeria", "2,381,740 Km²", 10, 10, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("a045e257-e470-4fa0-b57e-241699ba18dc"), "Kazakhstan", "2,724,900 Km²", 9, 9, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("cc5e520e-b8f4-4f5e-a1ca-2c2375a584bf"), "Argentina", "2,780,400 Km²", 8, 8, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("bd502f83-96ac-49c0-bb05-4e9a015ac0e1"), "India", "3,287,263 Km²", 7, 7, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2ca04a9a-552e-42a6-bd71-10bc35e3d3f7"), "Australia", "7,741,220 Km²", 6, 6, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("fba560d3-e0d9-4198-9c19-34e521406cbd"), "Brazil", "8,515,770 Km²", 5, 5, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("34cd67c6-4f81-4aa4-83f9-b5b1106a8a64"), "China", "9,596,960 Km²", 4, 4, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("b027d463-9baf-48be-877a-9532b70e9ceb"), "United States", "9,833,517 Km²", 3, 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("700ac1a7-0296-4861-9361-9b64801942b2"), "US", "9,833,517 Km²", 3, 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("2e7e48a1-e65d-498c-8b89-ed37c6ff3e2b"), "USA", "9,833,517 Km²", 3, 3, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("88f36a7f-c8de-4ede-8d4c-33f0cbcf042b"), "Canada", "9,984,670 Km²", 2, 2, new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("ce8574ce-26f6-4a93-bd6b-a0316f8940dd"), "China", "1,439,323,776", 1, 1, new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("fac3d98e-656b-4c43-899d-3a0f62d2485b"), "Indonesia", "210,693", 10, 10, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("61713893-8f93-45f8-b460-5c3acabdf6cb"), "Monaco", "2.02 Km²", 2, 2, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("ab751480-bf1c-4a85-8cd6-4f05de1de83a"), "Tuvalu", "26 Km²", 4, 4, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("d3fc1931-b08f-4893-9f3b-deea37e2889d"), "Bangladesh", "153,700,000", 4, 4, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("4467d9c7-0f0d-4041-a71a-16c379a384b1"), "India", "207,000,000", 3, 3, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("9b10e61c-d537-4e50-be87-e8e208db1106"), "Pakistan", "212,300,000", 2, 2, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("a00bca65-95cc-4820-9643-b92f44814241"), "Indonesia", "231,000,000", 1, 1, new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("4513fc40-3d58-43b5-9c8c-1d68d06258fc"), "Luxembourg", "7.238", 10, 10, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("8f33bd2c-515f-459e-b741-a3de0acee2ba"), "Austria", "7.294", 9, 9, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("ff427fa5-d192-486c-870e-9c51dec764e5"), "New Zealand", "7.300", 8, 8, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("34f02b0d-6fa0-4fe3-82ac-add9fb87920a"), "Sweden", "7.353", 7, 7, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("1a0520c6-2e9c-4d7f-80a2-423385f14f72"), "Netherlands", "7.449", 6, 6, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("a17bc31b-2614-4dc6-b3da-095f2984439b"), "Norway", "7.488", 5, 5, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("c3c49a6f-91fb-4cfe-90e8-e804a712fba7"), "Iceland", "7.504", 4, 4, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("dfe9aefb-c6a5-4fd6-a8c8-d44e6916af2e"), "Nauru", "21 Km²", 3, 3, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("e952920d-a040-42b9-91a5-0d37ba6fabc1"), "Switzerland", "7.560", 3, 3, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("16e63adb-524a-4339-98ba-bd149f1455bd"), "Finland", "7.809", 1, 1, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("f43f0bf2-9c6b-4c46-903d-df0673156c43"), "Malta", "316 Km²", 10, 10, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("db50c390-b73b-45ac-b51c-2e16075f8c30"), "Maldives", "300 Km²", 9, 9, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("7e0ffcff-4654-4757-aef0-a7a30cfd0cda"), "nevis", "261 Km²", 8, 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("ee38b690-23e4-4e06-964a-fca36a361ec9"), "kitts", "261 Km²", 8, 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("afecdbde-30f8-4011-bd6d-19ef67612489"), "Saint nevis", "261 Km²", 8, 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("e1af8ab0-2db9-4ff4-874a-8ad066db06d2"), "Saint kitts", "261 Km²", 8, 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("f6fe9038-a13e-484e-b654-57c7b3331293"), "Saint kitts and nevis", "261 Km²", 8, 8, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("df6458dc-ef68-4746-8e7f-504af7b25fc4"), "Marshall islands", "181 Km²", 7, 7, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("6242f756-a1cf-4675-b812-0c99b6b908a6"), "Liechtenstein", "160 Km²", 6, 6, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("9bc60ddc-d231-40f8-9095-75cb975d232e"), "San Marino", "61 Km²", 5, 5, new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("22a8af78-8de8-466d-979e-d925a316c1e0"), "Denmark", "7.646", 2, 2, new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("43b806c2-43d0-464c-b0fd-76e8eb6ee793"), "Afghanistan", "2.567", 1, 1, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("4d7d9f7e-a541-47aa-a767-687f057e8d27"), "India", "466,084", 5, 5, new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("f1d2fe64-7a5e-4d25-96a3-4449ae5d2122"), "South Sudan", "2.817", 2, 2, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("d270baa4-74c3-4004-905a-67c3fdcc9ee8"), "Chad", "16.1", 5, 5, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("d5cf3c21-a42a-479f-a99e-66e6f1680d67"), "Mali", "16.1", 4, 4, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("3d683cbb-e3be-48a7-aad5-ccb990de6bf6"), "Angola", "15.9", 3, 3, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("0498ce49-cc03-4ff1-8584-6d5573d7754c"), "Uganda", "15.7", 2, 2, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("0dfa5600-bd00-4622-8930-d731c11cff94"), "Niger", "14.8", 1, 1, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("c0486c52-1086-49e6-8496-7e303fad81e2"), "Russia", "1991", 10, 10, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("af44ab02-8b8e-4b5c-b9f1-0401ce0a125e"), "Herzegovina", "1992", 9, 9, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("af44ab02-8b8e-4b5c-b9f1-0400ce42125e"), "Bosnia", "1992", 9, 9, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("af44ab02-8b8e-4b5c-b9f1-04000e4a125e"), "Bosnia and Herzegovina", "1992", 9, 9, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("3a90a620-a621-46a7-a777-f8da3a052865"), "Slovakia", "1993", 8, 8, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("09c1915e-c903-40cb-b894-35f0d509fbf2"), "Czechia", "1993", 7, 8, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("3e3c0bff-8de3-4b33-ba4d-68cf348915cb"), "The Czech Republic", "1993", 7, 8, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("6e3bc240-027d-453b-8701-e1331897ec8b"), "Czech Republic", "1993", 7, 8, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("148347d1-63cf-408d-b16c-225d67b7ac15"), "Eritrea", "1993", 6, 6, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("d6dcc444-5b8b-4ae1-8bc8-e11090e402a8"), "Palau", "1994", 5, 5, new Guid("00437064-4748-470c-b77e-046703a2a19a") }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "AnswerText", "ExtraInfo", "Place", "Points", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("efa97963-58ad-407b-ab2f-367df79981a1"), "Timor-Leste", "2002", 4, 4, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("30c19344-43ce-4c31-b1a8-30978eb68a98"), "East Timor", "2002", 4, 4, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("30c19344-43ce-4c31-b1a8-30972eb62a98"), "Timor", "2002", 4, 4, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("7eb80550-84dc-4159-99a6-47e5e454e758"), "Montenegro", "2006", 3, 3, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("317e56c2-307f-4ccb-8b06-177e47c544c1"), "Serbia", "2006", 2, 3, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("48aeb621-be43-49f9-9754-4ce7a860079b"), "Austria", "", 10, 10, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("62b028ff-68a9-4f51-ae53-fef870238903"), "Australia", "", 9, 9, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("779a6523-8138-4b89-9c9c-42ad235b6b2f"), "Armenia", "", 8, 8, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("fe1823b6-cd4a-4b79-83f6-c09bce2dc3f3"), "DRC", "16.7", 6, 6, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("305f6a56-f15e-4d3a-a283-89298cddcf2f"), "Argentina", "", 7, 7, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("6eaa5dec-aea1-4c3b-87e0-e39d8e9dd258"), "Democratic Republic of the Congo", "16.7", 6, 6, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("6eaa5dec-aea1-4c3b-87e0-e1918e2dd258"), "DRC", "16.7", 6, 6, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("3ac6f709-7a77-45b8-9bce-e33db2d44b8e"), "Venezuela", "36.69", 6, 6, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("e16ae3aa-2d49-4d4c-b640-e1d0533df08b"), "Belize", "37.90", 5, 5, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("4710cb1b-fcd6-46c6-b685-2e7768c56126"), "Honduras", "38.93", 4, 4, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("eb4a6e45-a008-4e17-84ee-4e1442a35e7f"), "Lesotho", "41.25", 3, 3, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("33bcd497-740f-4445-b6c0-96a60af7e3e7"), "Jamaica", "43.85", 2, 2, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("145bc81f-9c2f-4ce2-8ca3-2a7a955ea59f"), "El Salvador", "52.02", 1, 1, new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("f610c82a-de99-4bc5-8ea1-cad8b0cee9a0"), "Austria", "44.5", 10, 10, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("939bbfc5-0bf0-4db8-a9ca-97c7b75a576b"), "Portugal", "44.6", 9, 9, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("6c288d97-a0dd-40dc-80a7-4efecb280e85"), "Slovenia", "44.9", 8, 8, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("30ab9b05-4b71-43e9-bea7-a9599df86b14"), "San Marino", "45.2", 7, 7, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("f8fc1c9a-5e5f-4ea4-a50c-d4bbc4af6a8b"), "Greece", "45.3 ", 6, 6, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("07c4580c-9203-43b9-82e1-4f6da22b19ca"), "Andorra", "46.2", 5, 5, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("d5c9aa40-fe6c-46e4-89a9-0e51f622bf9b"), "Italy", "46.5", 4, 4, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("6201102b-1f8b-4def-ab8d-f6e2965dd2f6"), "Germany", "47.8", 3, 3, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("1a6ca314-778f-4727-9fb4-f0edd365a052"), "Japan", "48.6", 2, 2, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("2219d699-6c45-4f24-92f3-74408a98a7b6"), "Monaco", "55.4", 1, 1, new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("01dec07b-0695-43b7-8929-058535b2287b"), "Benin", "17.0", 10, 10, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("2caeb39a-f3f0-4be2-9f0c-05ab896c63c9"), "Mozambique", "17.0", 9, 9, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("6db5a9b0-b02d-4d8e-bc0a-314f92470ded"), "Zambia", "16.9", 8, 8, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("c0db83a9-e421-4d50-9cf8-d68c38d47666"), "Malawi", "16.8", 7, 7, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("9e103d6e-b776-42f5-800a-0f751e216f1d"), "Republic Congo", "16.7", 6, 6, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("9e103d6e-b776-42f5-800a-0f751e816f9d"), "Democratic Republic Congo", "16.7", 6, 6, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("907817de-8854-46eb-8918-6a43a4aba2fc"), "Congo", "16.7", 6, 6, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("6eaa5dec-aea1-4c3b-87e0-e3908e2dd258"), "DR Congo", "16.7", 6, 6, new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("2d5a1891-8ca1-4a55-92d8-f93a2b711281"), "Antigua and Barbuda", "", 6, 6, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("2d3169f7-d37e-47b1-9804-157ec7342233"), "South Sudan", "2011", 1, 1, new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("637d90dc-2710-4408-8d4d-8227584e1c6f"), "Andorra", "", 4, 4, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("8d729a10-f2fc-4c33-aa66-90786fd5f472"), "Japan", "$49,100,000", 9, 9, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("971b7735-f800-444a-a882-a7683e83cf43"), "Angola", "", 5, 5, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("113b38de-3d33-40a1-9530-057fd79cc06a"), "Germany", "$52,800,000", 7, 7, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("f33a9cb0-f064-497e-bb13-44760f588090"), "Saudi Arabia", "$57,500,000", 6, 6, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("b646a131-3ca2-48d0-8dbb-03442adb9a45"), "The united kingdom", "$59,200,000", 5, 5, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("06f764a8-be78-4ab3-848d-201d8a43644e"), "United kingdom", "$59,200,000", 5, 5, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("3778093a-5550-4e5a-ade7-6b8635a9c43e"), "UK", "$59,200,000", 5, 5, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("0bd042b5-3c3b-4d7e-b332-cd37c7193c49"), "Russia", "$61,700,000", 4, 4, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("b0787637-a0b1-41ce-9ae4-f854bba7ca49"), "India", "$72,900,000", 3, 3, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("8ae25016-b3a3-4102-9e91-c692a1c016a4"), "China", "$252,000,000", 2, 2, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("ee0be4d9-6d5e-47b2-b2cc-5ea0c69a44b3"), "South korea", "$45,700,000", 10, 10, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("8300df46-baf2-4ef9-8972-ddc25886eaf2"), "US", "$778,000,000", 1, 1, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("ace29ae5-1859-4e21-aa5d-0fe102c85a44"), "USA", "$778,000,000", 1, 1, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("334a6b9a-352a-4982-983c-f824b806db6a"), "India", "3.573", 10, 10, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("fce58607-69c1-4f5d-a7d3-8d18dc71e900"), "Malawi", "3.538", 9, 9, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("f2b80c75-f59e-4c8e-aa59-c38e39103f71"), "Yemen", "3.527", 8, 8, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("f01ec6ed-dbce-4233-ace4-7020a94e3595"), "Botswana", "3.479", 7, 7, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("d30cfa90-e839-47ce-ad3f-48134d9d1dbb"), "Tanzania", "3.476", 6, 6, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("78a65eda-698d-4479-80ed-dedb9b05b70e"), "CAR", "3.476", 5, 5, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("fb7cb7a7-b194-4789-a595-4ea2ddefb47f"), "Central african republic", "3.476", 5, 5, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("fa76af62-c4a8-4c41-a13f-5a5cef75e3a7"), "Rwanda", "3.312", 4, 4, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("8a962feb-70e4-4292-8dbf-12d660a09555"), "Zimbabwe", "3.299", 3, 3, new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("6eeaeb73-f041-4c4c-9703-71d3d0c5dcaa"), "United states", "$778,000,000", 1, 1, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("5fa4f9d8-f5be-4a74-b5f7-7e85e0d1caf1"), "Nauru", "61.0%", 1, 1, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("6e6f3ec5-fe3c-4780-9f2e-06e7b73b2185"), "France", "$52,700,000", 8, 8, new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("d62516b9-603f-4f97-849c-cb01cbb1737f"), "USA", "36.2%", 10, 10, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("b4e285aa-877b-455d-973b-d9233bd27f65"), "Kuwait", "37.9%", 9, 9, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("050f3b61-47a5-4a75-ae9a-9c37e7ca55f5"), "Micronesia", "45.8%", 8, 8, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("c30cadfe-954b-4f68-a0e3-f1c5bbf6149e"), "US", "36.2%", 10, 10, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("3fde4ca4-902c-4d56-804d-294224a8b690"), "Palau", "55.3%", 2, 2, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("6e4aced9-a33e-49fa-a9e3-561ce8cd75b2"), "Kiribati", "46.0%", 7, 7, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("454eec1a-d823-498a-829e-da37f0cae85c"), "Samoa", "47.3%", 6, 6, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("f4d99ae3-6dee-42ca-8a1f-cf2981fdeada"), "United states", "36.2%", 10, 10, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("b805b40b-b5a6-4e66-b588-d3981bdf2025"), "Tonga", "48.2%", 5, 5, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("d76355ef-92a8-4d70-813d-bd6e78a42ca5"), "Afghanistan", "", 1, 1, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("f1ee25e6-9c09-4152-b5b9-bb8c21f105d3"), "Marshal islands", "52.9%", 3, 3, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("9a8b9078-e33f-40b9-b53e-17e50fc61d54"), "Albania", "", 2, 2, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("56c276ef-fb77-4d69-988a-0117a073472a"), "Algeria", "", 3, 3, new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("5fec6942-3ead-46cb-b416-daa9f858b668"), "Tuvalu", "51.6%", 4, 4, new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") }
                });

            migrationBuilder.InsertData(
                table: "CategoryQuestions",
                columns: new[] { "CategoryId", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("961761d2-f15d-4853-b8f9-91b9745be1b8") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("5a563a77-0a11-459a-8162-d886acf1f898") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("98220fe9-135d-423b-ab8f-14d57eafcb38") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("03744a50-cdd5-43c1-898d-b69df8168820") },
                    { new Guid("00000000-0000-0000-f000-900000000007"), new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("43cb9f67-8568-4a8d-81c6-110a622787bb") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("f6d70c09-f3a9-4c9e-8baf-808916af4291") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("9cafb85f-730b-4a26-a661-b2d2dda74534") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("be90a71f-c2ee-4178-96c3-8adb2293b613") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("00437064-4748-470c-b77e-046703a2a19a") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("94e5f344-ef61-44c6-b209-9b805ca42880") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("26775c7d-97ea-415d-b73c-7629759656cf") },
                    { new Guid("00000000-0000-0000-f000-900000000007"), new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("f5b97548-cb81-44b5-8830-aba39f71c079") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("e75284fe-a777-4d85-aad5-e68b817b2d50") },
                    { new Guid("00000000-0000-0000-0000-100000000001"), new Guid("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
                    { new Guid("00000000-1001-1001-1001-500000100005"), new Guid("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
                    { new Guid("00000000-1001-1001-1001-500000100005"), new Guid("da899e4f-63f2-4560-b693-1c1f13a17d13") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryQuestions_QuestionId",
                table: "CategoryQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RoomId",
                table: "Players",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomQuestions_QuestionId",
                table: "RoomQuestions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "CategoryQuestions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "RoomQuestions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
