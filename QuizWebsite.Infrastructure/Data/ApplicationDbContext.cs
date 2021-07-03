using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
