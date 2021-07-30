using QuizWebsite.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class RoomResponseDto : BaseDto
    {
        public string Name { get; set; }
        public bool Public { get; set; }
        public List<PlayerResponseDto> Players { get; set; }
    }
}
