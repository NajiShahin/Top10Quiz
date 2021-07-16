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
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("6e9f33c2-9bd1-4c4d-b508-c09fd13d6040") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("1f56b20c-54b1-40a3-9b60-c510f27912ae") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("00437064-4748-470c-b77e-046703a2a19a") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("e75284fe-a777-4d85-aad5-e68b817b2d50") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("f1b44064-927d-45bf-9fe4-14c2d98d774c") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("43cb9f67-8568-4a8d-81c6-110a622787bb") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("f5b97548-cb81-44b5-8830-aba39f71c079") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("9cafb85f-730b-4a26-a661-b2d2dda74534") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("9429778e-df46-4c10-a0d4-80fecbfdf3f9") },

new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("62732694-8646-4ded-a4ac-c51dfce4dfc6") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("db0edb42-f12b-432f-82ec-5d16a51f13f0") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("03744a50-cdd5-43c1-898d-b69df8168820") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("961761d2-f15d-4853-b8f9-91b9745be1b8") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("4cfea5e6-dec6-40ea-8d7e-6f8034a45b82") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("94e5f344-ef61-44c6-b209-9b805ca42880") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("3e7b6791-8e14-4284-8201-87d7ddc0850b") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-0000-100000000001"), QuestionId = Guid.Parse("f6d70c09-f3a9-4c9e-8baf-808916af4291") },

new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-f000-900000000007"), QuestionId = Guid.Parse("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-1001-1001-1001-500000100005"), QuestionId = Guid.Parse("7301c840-a51f-4e7e-9ead-a5d8e50d510b") },

new CategoryQuestions { CategoryId = Guid.Parse("00000000-0000-0000-f000-900000000007"), QuestionId = Guid.Parse("da899e4f-63f2-4560-b693-1c1f13a17d13") },
new CategoryQuestions { CategoryId = Guid.Parse("00000000-1001-1001-1001-500000100005"), QuestionId = Guid.Parse("da899e4f-63f2-4560-b693-1c1f13a17d13") }
                );
        }
    }
}
