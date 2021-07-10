using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Infrastructure.Data.Seeding
{
    public class QuestionSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
new Question { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), QuestionText = "What are the biggest countries of the world", CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001") },
new Question { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), QuestionText = "What countries have the biggest population", CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001") },

new Question { Id = Guid.Parse(" be90a71f-c2ee-4178-96c3-8adb2293b613"), QuestionText = "What are the smallest countries of the world", CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001") }
                );
        }
    }
}
