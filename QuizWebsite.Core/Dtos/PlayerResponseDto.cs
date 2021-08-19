using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class PlayerResponseDto : BaseDto
    {
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public int Score { get; set; }
        public int AnsweredNumber { get; set; } //0 = not answered yet, -1 = answered wrong, 1-10 = what user answered
        public string AnsweredText { get; set; }
        public string ColorCode { get; set; }
        public RoomResponseDto Room { get; set; }
    }
}
