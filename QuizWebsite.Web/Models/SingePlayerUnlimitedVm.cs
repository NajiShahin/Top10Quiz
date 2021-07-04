using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebsite.Web.Models
{
    public class SingePlayerUnlimitedVm
    {
        public Player Player { get; set; }
        public List<Question> Questions { get; set; }
    }
}
