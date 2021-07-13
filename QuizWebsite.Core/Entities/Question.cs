using QuizWebsite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class Question : EntityBase
    {
        public string QuestionText { get; set; }
        public string QuestionType { get; set; } //Top10 = top10 quiz, other types can also be created
        public Guid CategoryId { get; set; }
        public ICollection<CategoryQuestions> CategoryQuestions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
