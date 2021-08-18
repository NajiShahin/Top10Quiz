using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class RoomQuestionsResponseDto : BaseDto
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public ICollection<CategoryResponseDto> Category { get; set; }
        public int QuestionNumber { get; set; }
        public bool activeQuestion { get; set; }
        public long QuestionStart { get; set; }
        public long QuestionEnd { get; set; }
    }
}
