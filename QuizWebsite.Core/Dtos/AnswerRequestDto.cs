using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class AnswerRequestDto : BaseDto
    {
        public string AnswerText { get; set; }
    }
}
