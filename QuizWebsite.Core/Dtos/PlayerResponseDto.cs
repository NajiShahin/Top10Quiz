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
        public bool Ready { get; set; }
        public string ColorCode { get; set; }
        public RoomResponseDto Room { get; set; }
    }
}
