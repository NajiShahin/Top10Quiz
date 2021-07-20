using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class RoomResponseDto : BaseDto
    {
        public bool Public { get; set; }
        public int Players { get; set; }
    }
}
