using QuizWebsite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class Room : EntityBase
    {
        public bool Public { get; set; }
        public int Players { get; set; }
    }
}
