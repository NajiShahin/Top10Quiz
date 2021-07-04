﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizWebsite.Infrastructure.Data;

namespace QuizWebsite.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizWebsite.Core.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtraInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("094b7df9-86f4-4fe6-b111-f4c84e6dd891"),
                            AnswerText = "Russia",
                            ExtraInfo = "17,098,242 Km²",
                            Points = 1,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("56fc971e-df71-4a95-9a7d-c0c427329257"),
                            AnswerText = "Canada",
                            ExtraInfo = "9,984,670 Km²",
                            Points = 2,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("5d4711c6-c55f-4132-bfbc-75392910eab6"),
                            AnswerText = "USA",
                            ExtraInfo = "9,833,517 Km²",
                            Points = 3,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("de323254-5f38-469a-b7ba-c300adb543d9"),
                            AnswerText = "The United States",
                            ExtraInfo = "9,833,517 Km²",
                            Points = 3,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("17dce4ad-5e0a-445c-9bc8-ac7be1e6661c"),
                            AnswerText = "United States",
                            ExtraInfo = "9,833,517 Km²",
                            Points = 3,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("760ed086-9071-4ce0-9ab0-ce562b878f2e"),
                            AnswerText = "China",
                            ExtraInfo = "9,596,960 Km²",
                            Points = 4,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("bbb3de9d-e494-406e-a3ec-a25cb16547dd"),
                            AnswerText = "Brazil",
                            ExtraInfo = "8,515,770 Km²",
                            Points = 5,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("b9fc51d0-ff8b-4c7f-9b09-b519864d8aef"),
                            AnswerText = "Australia",
                            ExtraInfo = "7,741,220 Km²",
                            Points = 6,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("2c83c976-2030-49e8-96af-c71f1c0c3c9c"),
                            AnswerText = "India",
                            ExtraInfo = "3,287,263 Km²",
                            Points = 7,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("42298e36-ab1a-44d8-8d8e-705325fe2a2c"),
                            AnswerText = "Argentina",
                            ExtraInfo = "2,780,400 Km²",
                            Points = 8,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("a9f704fa-e064-4efa-9c1c-e6151f2464d1"),
                            AnswerText = "Kazakhstan",
                            ExtraInfo = "2,724,900 Km²",
                            Points = 9,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("62fba627-cceb-4a70-9740-322dfa27b2bc"),
                            AnswerText = "Algeria",
                            ExtraInfo = "2,381,740 Km²",
                            Points = 10,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000001")
                        },
                        new
                        {
                            Id = new Guid("97c325d1-9ef6-401f-b353-3aee47a96919"),
                            AnswerText = "China",
                            ExtraInfo = "1,439,323,776",
                            Points = 1,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("beb8946e-0481-4ffe-96a0-1900869a4dfa"),
                            AnswerText = "India",
                            ExtraInfo = "1,380,004,385",
                            Points = 2,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("46c36bcb-4e0d-4f37-8447-26312c0b3023"),
                            AnswerText = "USA",
                            ExtraInfo = "331,002,651",
                            Points = 3,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("e0766d49-dfc6-4eca-b8a3-672f8953c78f"),
                            AnswerText = "The United States",
                            ExtraInfo = "331,002,651",
                            Points = 3,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("59d62492-84b5-4b38-a6a3-83de26ddfc4e"),
                            AnswerText = "United States",
                            ExtraInfo = "331,002,651",
                            Points = 3,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("2b69a7eb-d1ff-4143-8320-e1b1c33d5d8f"),
                            AnswerText = "Indonesia",
                            ExtraInfo = "273,523,615",
                            Points = 4,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("47e649af-ecb6-4a28-b33f-625eec660823"),
                            AnswerText = "Pakistan",
                            ExtraInfo = "220,892,340",
                            Points = 5,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("e458eed1-7b94-405d-8112-03070b77780d"),
                            AnswerText = "Brazil",
                            ExtraInfo = "212,559,417",
                            Points = 6,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("14bc3c2a-72c4-4c24-9d29-c2faca41478f"),
                            AnswerText = "Nigeria",
                            ExtraInfo = "206,139,589",
                            Points = 7,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("7b7a7c61-630b-47b9-aa96-affe99dea101"),
                            AnswerText = "Bangladesh",
                            ExtraInfo = "164,689,383",
                            Points = 8,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("21eb2ad6-a1ce-49e9-8743-0ea9575d59ab"),
                            AnswerText = "Russia",
                            ExtraInfo = "145,934,462",
                            Points = 9,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        },
                        new
                        {
                            Id = new Guid("59c1fa07-fdc4-4d90-b11a-9832d289c889"),
                            AnswerText = "Mexico",
                            ExtraInfo = "128,932,753",
                            Points = 10,
                            QuestionId = new Guid("00000000-0000-0000-0000-000000000002")
                        });
                });

            modelBuilder.Entity("QuizWebsite.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-100000000001"),
                            Name = "Countries"
                        });
                });

            modelBuilder.Entity("QuizWebsite.Core.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CategoryId = new Guid("00000000-0000-0000-0000-100000000001"),
                            QuestionText = "What are the biggest countries of the world?"
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CategoryId = new Guid("00000000-0000-0000-0000-100000000001"),
                            QuestionText = "What countries have the biggest population?"
                        });
                });

            modelBuilder.Entity("QuizWebsite.Core.Entities.Answer", b =>
                {
                    b.HasOne("QuizWebsite.Core.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizWebsite.Core.Entities.Question", b =>
                {
                    b.HasOne("QuizWebsite.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
