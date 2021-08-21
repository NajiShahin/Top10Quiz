using QuizWebsite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class Player : EntityBase
    {
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public int AnsweredNumber { get; set; } //0 = not answered yet, -1 = answered wrong, 1-10 = what user answered
        public string AnsweredText { get; set; }
        public int Score { get; set; }
        public string ColorCode { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
