using QuizWebsite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class Room : EntityBase
    {
        public string Name { get; set; }
        public bool Public { get; set; }
        public ICollection<Player> Players { get; set; }
        public int QuestionAmount { get; set; }
        public ICollection<RoomQuestions> RoomQuestions { get; set; }
    }
}
