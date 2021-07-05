using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class AnswerRequestDto : BaseDto
    {
        public int Points { get; set; } //How many points you get from the answer
        public string AnswerText { get; set; }
        public string ExtraInfo { get; set; } //If the question is biggest population countries this will be the population of the country Ex. AnswerText = China, ExtraInfo = 1,444,948,110
    }
}
