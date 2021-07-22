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
        public int Score { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
