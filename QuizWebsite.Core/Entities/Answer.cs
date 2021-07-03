using QuizWebsite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class Answer : EntityBase
    {
        public int Points { get; set; } //How many points you get from the answer
        public string AnswerText { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
