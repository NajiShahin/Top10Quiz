using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class RoomQuestions
    {
        int questionNumber;
        public Guid RoomId { get; set; }
        public Guid QuestionId { get; set; }
        public Room Room { get; set; }
        public Question Question { get; set; }
    }
}
