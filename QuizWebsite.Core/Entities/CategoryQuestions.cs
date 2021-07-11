using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class CategoryQuestions
    {
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
    }
}
