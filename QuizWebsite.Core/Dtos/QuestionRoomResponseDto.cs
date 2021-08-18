﻿using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class QuestionRoomResponseDto : BaseDto
    {
        public string QuestionText { get; set; }
        public ICollection<CategoryResponseDto> Category { get; set; }
        public int QuestionNumber { get; set; }
        public bool activeQuestion { get; set; }
        public DateTime QuestionStart { get; set; }
        public DateTime QuestionEnd { get; set; }
    }
}
