using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
using QuizWebsite.Infrastructure.Data.Seeding;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CategoryQuestions> CategoryQuestions { get; set; }
        public DbSet<RoomQuestions> RoomQuestions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryQuestions>()
                .ToTable("CategoryQuestions")
                .HasKey(ue => new { ue.CategoryId, ue.QuestionId });
            modelBuilder.Entity<CategoryQuestions>()
                .HasOne(ue => ue.Category)
                .WithMany(e => e.CategoryQuestions)
                .HasForeignKey(ue => ue.CategoryId);
            modelBuilder.Entity<CategoryQuestions>()
                .HasOne(ue => ue.Question)
                .WithMany(u => u.CategoryQuestions)
                .HasForeignKey(ue => ue.QuestionId);
            modelBuilder.Entity<RoomQuestions>()
                .ToTable("RoomQuestions")
                .HasKey(rq => new { rq.RoomId, rq.QuestionId });
            modelBuilder.Entity<RoomQuestions>()
                .HasOne(ue => ue.Room)
                .WithMany(u => u.RoomQuestions)
                .HasForeignKey(ue => ue.RoomId);
            modelBuilder.Entity<RoomQuestions>()
                .HasOne(ue => ue.Question)
                .WithMany(u => u.RoomQuestions)
                .HasForeignKey(ue => ue.QuestionId);


            CategorySeeder.Seed(modelBuilder);
            QuestionSeeder.Seed(modelBuilder);
            AnswerSeeder.Seed(modelBuilder);
            CategoryQuestionsSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
