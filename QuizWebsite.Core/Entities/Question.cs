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
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTime DateTimeChanged { get; set; }
        public ChangeFrequency ChangeFrequency { get; set; } //Frequency that you'll manually have to check if answers are correct
        public ICollection<CategoryQuestions> CategoryQuestions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
