using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class QuestionResponseDto
    {
        public string QuestionText { get; set; }
        public ICollection<CategoryResponseDto> Category { get; set; }
        public ICollection<AnswerDetailRequestDto> Answers { get; set; }
    }
}
