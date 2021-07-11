using QuizWebsite.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<CategoryQuestions> CategoryQuestions { get; set; }
    }
}
