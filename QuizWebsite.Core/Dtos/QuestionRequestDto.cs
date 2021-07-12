using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class QuestionRequestDto : BaseDto
    {
        public string QuestionText { get; set; }
        public CategoryRequestDto Category { get; set; }
        public ICollection<AnswerDetailRequestDto> Answers { get; set; }
    }
}
