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
new Answer { Id = Guid.NewGuid(), AnswerText = "China", ExtraInfo = "9,596,960 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 4 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Brazil", ExtraInfo = "8,515,770 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 5 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Australia", ExtraInfo = "7,741,220 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 6 },
new Answer { Id = Guid.NewGuid(), AnswerText = "India", ExtraInfo = "3,287,263 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 7 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Argentina", ExtraInfo = "2,780,400 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 8 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Kazakhstan", ExtraInfo = "2,724,900 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 9 },
new Answer { Id = Guid.NewGuid(), AnswerText = "Algeria", ExtraInfo = "2,381,740 Km²", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Points = 10 }




                );
        }
    }
}
