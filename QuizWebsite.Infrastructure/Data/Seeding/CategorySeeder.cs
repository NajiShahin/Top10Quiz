using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Infrastructure.Data.Seeding
{
    public class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
new Category { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Countries" }

                );
        }
    }
}
