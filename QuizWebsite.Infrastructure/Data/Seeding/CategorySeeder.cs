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
new Category { Id = Guid.Parse("00000000-0000-0000-0000-100000000001"), Name = "Countries" },
new Category { Id = Guid.Parse("00000000-0000-0000-f000-900000000007"), Name = "History" },
new Category { Id = Guid.Parse("00000000-1001-1001-1001-500000100005"), Name = "People" }

                );
        }
    }
}
