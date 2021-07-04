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
        public string ExtraInfo { get; set; } //If the question is biggest population countries this will be the population of the country Ex. AnswerText = China, ExtraInfo = 1,444,948,110
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
