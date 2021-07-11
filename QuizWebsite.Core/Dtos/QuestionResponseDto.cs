using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class QuestionResponseDto : BaseDto
    {
        public string QuestionText { get; set; }
        public ICollection<CategoryResponseDto> Category { get; set; }
        public ICollection<AnswerResponseDto> Answers { get; set; }
    }
}
