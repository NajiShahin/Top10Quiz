using QuizWebsite.Core.Entities;
using QuizWebsite.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        public Question GetQuestionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Question> GetQuestionsRandomOrder()
        {
            throw new NotImplementedException();
        }

        public Question GetRandomQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
