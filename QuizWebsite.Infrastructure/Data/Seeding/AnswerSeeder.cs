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
new Answer { Id = Guid.NewGuid(), AnswerText = "Mexico", ExtraInfo = "128,932,753", QuestionId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Points = 10 },

new Answer { Id = Guid.Parse("b2710771-e4ff-4970-9246-fd87c35945d0"), AnswerText = "Vatican", ExtraInfo = "0.49 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 1 },
new Answer { Id = Guid.Parse("26ad01ed-ff4e-488a-8075-f38e0a53dd1c"), AnswerText = "Vatican City", ExtraInfo = "0.49 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 1 },
new Answer { Id = Guid.Parse("61713893-8f93-45f8-b460-5c3acabdf6cb"), AnswerText = "Monaco", ExtraInfo = "2.02 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 2 },
new Answer { Id = Guid.Parse("dfe9aefb-c6a5-4fd6-a8c8-d44e6916af2e"), AnswerText = "Nauru", ExtraInfo = "21 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 3 },
new Answer { Id = Guid.Parse("ab751480-bf1c-4a85-8cd6-4f05de1de83a"), AnswerText = "Tuvalu", ExtraInfo = "26 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 4 },
new Answer { Id = Guid.Parse("9bc60ddc-d231-40f8-9095-75cb975d232e"), AnswerText = "San Marino", ExtraInfo = "61 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 5 },
new Answer { Id = Guid.Parse("6242f756-a1cf-4675-b812-0c99b6b908a6"), AnswerText = "Liechtenstein", ExtraInfo = "160 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 6 },
new Answer { Id = Guid.Parse("df6458dc-ef68-4746-8e7f-504af7b25fc4"), AnswerText = "Marshall islands", ExtraInfo = "181 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 7 },
new Answer { Id = Guid.Parse("f6fe9038-a13e-484e-b654-57c7b3331293"), AnswerText = "Saint kitts and nevis", ExtraInfo = "261 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 8 },
new Answer { Id = Guid.Parse("e1af8ab0-2db9-4ff4-874a-8ad066db06d2"), AnswerText = "Saint kitts", ExtraInfo = "261 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 8 },
new Answer { Id = Guid.Parse("afecdbde-30f8-4011-bd6d-19ef67612489"), AnswerText = "Saint nevis", ExtraInfo = "261 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 8 },
new Answer { Id = Guid.Parse("ee38b690-23e4-4e06-964a-fca36a361ec9"), AnswerText = "kitts", ExtraInfo = "261 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 8 },
new Answer { Id = Guid.Parse("7e0ffcff-4654-4757-aef0-a7a30cfd0cda"), AnswerText = "nevis", ExtraInfo = "261 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 8 },
new Answer { Id = Guid.Parse("db50c390-b73b-45ac-b51c-2e16075f8c30"), AnswerText = "Maldives", ExtraInfo = "300 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 9 },
new Answer { Id = Guid.Parse("f43f0bf2-9c6b-4c46-903d-df0673156c43"), AnswerText = "Malta", ExtraInfo = "316 Km²", QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613"), Points = 10 }
                );
        }
    }
}
