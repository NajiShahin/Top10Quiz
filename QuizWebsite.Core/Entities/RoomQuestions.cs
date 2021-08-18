using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class RoomQuestions
    {
        public int QuestionNumber { get; set; }
        public bool activeQuestion { get; set; }
        public long QuestionStart { get; set; }
        public long QuestionEnd { get; set; }
        public Guid RoomId { get; set; }
        public Guid QuestionId { get; set; }
        public Room Room { get; set; }
        public Question Question { get; set; }
    }
}
