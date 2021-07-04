﻿using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Interfaces
{
    public interface IQuestionService
    {
        ICollection<Question> GetQuestionsRandomOrder();
        Question GetQuestionById(Guid id);
        Question GetRandomQuestion();
    }
}
