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
new Question { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), QuestionText = "What are the biggest countries of the world" },
new Question { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), QuestionText = "What countries have the biggest population"},

new Question { Id = Guid.Parse(" be90a71f-c2ee-4178-96c3-8adb2293b613"), QuestionText = "What are the smallest countries of the world" },
new Question { Id = Guid.Parse(" 3aa5a782-c701-4a75-b4f0-98bab8d144e2"), QuestionText = "What are the happiest countries (according to the World Happiness Report in 2020)" },
new Question { Id = Guid.Parse(" 98220fe9-135d-423b-ab8f-14d57eafcb38"), QuestionText = "What countries have the biggest population of muslims" },
new Question { Id = Guid.Parse(" 962c9cae-4ba2-4506-98c2-1ccdd9535b40"), QuestionText = "What countries have the biggest population of catholics" },
new Question { Id = Guid.Parse(" 8630be8d-b3e3-4b1e-babc-207819fe2f46"), QuestionText = "What countries have the highest GDP (nominal)" },
new Question { Id = Guid.Parse(" 26775c7d-97ea-415d-b73c-7629759656cf"), QuestionText = "What countries have the highest GDP per capita" },
new Question { Id = Guid.Parse(" 5c08cfa3-a2e0-43bd-a574-184cb3bde2d2"), QuestionText = "What countries have the highest prison population" },
new Question { Id = Guid.Parse(" 5a563a77-0a11-459a-8162-d886acf1f898"), QuestionText = "What are the least happiest countries (according to the World Happiness Report in 2020)" }, //10
new Question { Id = Guid.Parse(" 59dddd6c-7a6e-4e43-9869-088ef430421f"), QuestionText = "Which countries spend the most on their military" },



                );
        }
    }
}
