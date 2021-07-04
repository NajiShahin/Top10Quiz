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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CategorySeeder.Seed(modelBuilder);
            QuestionSeeder.Seed(modelBuilder);
            AnswerSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
