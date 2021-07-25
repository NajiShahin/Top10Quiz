using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Dtos
{
    public class PlayerRequestDto
    {
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public int Score { get; set; }
    }
}
