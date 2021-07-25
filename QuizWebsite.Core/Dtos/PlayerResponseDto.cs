﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class PlayerResponseDto
    {
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public int Score { get; set; }
        public RoomResponseDto Room { get; set; }
    }
}
