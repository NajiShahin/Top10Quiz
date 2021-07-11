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
new Question { Id = Guid.Parse(" 6e9f33c2-9bd1-4c4d-b508-c09fd13d6040"), QuestionText = "What are the most obese countries of the world (2016)" },
new Question { Id = Guid.Parse(" 1f56b20c-54b1-40a3-9b60-c510f27912ae"), QuestionText = "What are the first countries if you order them alphabetically (A-Z)" },
new Question { Id = Guid.Parse(" 00437064-4748-470c-b77e-046703a2a19a"), QuestionText = "What are the newest countries in the world" },
new Question { Id = Guid.Parse(" e75284fe-a777-4d85-aad5-e68b817b2d50"), QuestionText = "What are the countries with the youngest median age (2020)" },//15
new Question { Id = Guid.Parse(" f1b44064-927d-45bf-9fe4-14c2d98d774c"), QuestionText = "What are the countries with the oldest median age (2020)" },
new Question { Id = Guid.Parse(" 43cb9f67-8568-4a8d-81c6-110a622787bb"), QuestionText = "Countries with most homocides per 100,000 people" },
new Question { Id = Guid.Parse(" f5b97548-cb81-44b5-8830-aba39f71c079"), QuestionText = "What are the countries with the highest murder count per year" },


                );
        }
    }
}
