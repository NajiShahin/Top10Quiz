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
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("be90a71f-c2ee-4178-96c3-8adb2293b613") },

new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("3aa5a782-c701-4a75-b4f0-98bab8d144e2") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("98220fe9-135d-423b-ab8f-14d57eafcb38") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("962c9cae-4ba2-4506-98c2-1ccdd9535b40") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("8630be8d-b3e3-4b1e-babc-207819fe2f46") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("26775c7d-97ea-415d-b73c-7629759656cf") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("5c08cfa3-a2e0-43bd-a574-184cb3bde2d2") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("5a563a77-0a11-459a-8162-d886acf1f898") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("59dddd6c-7a6e-4e43-9869-088ef430421f") },
                );
        }
    }
}
