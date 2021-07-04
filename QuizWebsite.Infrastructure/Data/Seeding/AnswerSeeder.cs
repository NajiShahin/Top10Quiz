using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Infrastructure.Data.Seeding
{
    public class AnswerSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData(
new Answer { Id = Guid.NewGuid(), AnswerText = "Russia", ExtraInfo = "17,098,242 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 1 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Canada", ExtraInfo = "9,984,670 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 2 },
new Answer { Id = Guid.NewGuid(), AnswerText = "USA", ExtraInfo = "9,833,517 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 3 },
new Answer { Id = Guid.NewGuid(), AnswerText = "The United States", ExtraInfo = "9,833,517 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 3 },
new Answer { Id = Guid.NewGuid(), AnswerText = "United States", ExtraInfo = "9,833,517 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 3 },
new Answer { Id = Guid.NewGuid(), AnswerText = "China", ExtraInfo = "9,596,960 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 4 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Brazil", ExtraInfo = "8,515,770 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 5 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Australia", ExtraInfo = "7,741,220 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 6 },
new Answer { Id = Guid.NewGuid(), AnswerText = "India", ExtraInfo = "3,287,263 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 7 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Argentina", ExtraInfo = "2,780,400 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 8 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Kazakhstan", ExtraInfo = "2,724,900 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 9 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Algeria", ExtraInfo = "2,381,740 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 10 },


new Answer { Id = Guid.NewGuid(), AnswerText = "China", ExtraInfo = "1,439,323,776", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 1 },
new Answer { Id = Guid.NewGuid(), AnswerText = "India", ExtraInfo = "1,380,004,385", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 2 },
new Answer { Id = Guid.NewGuid(), AnswerText = "USA", ExtraInfo = "331,002,651", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 3 },
new Answer { Id = Guid.NewGuid(), AnswerText = "The United States", ExtraInfo = "331,002,651", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 3 },
new Answer { Id = Guid.NewGuid(), AnswerText = "United States", ExtraInfo = "331,002,651", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 3 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Indonesia", ExtraInfo = "273,523,615", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 4 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Pakistan", ExtraInfo = "220,892,340", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 5 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Brazil", ExtraInfo = "212,559,417", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 6 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Nigeria", ExtraInfo = "206,139,589", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 7 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Bangladesh", ExtraInfo = "164,689,383", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 8 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Russia", ExtraInfo = "145,934,462", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 9 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Mexico", ExtraInfo = "128,932,753", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 10 }


                );
        }
    }
}
