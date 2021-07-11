using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Infrastructure.Data.Seeding
{
    public class CategoryQuestionsSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryQuestions>().HasData(
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613") }

                );
        }
    }
}
