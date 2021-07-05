using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
using QuizWebsite.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizWebsite.Infrastructure.Services
{
    public class QuestionService
    {
        protected readonly ApplicationDbContext dbContext;
        public QuestionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Question GetQuestionById(Guid id)
        {
            return GetQuestions().SingleOrDefault(q => q.Id == id);
        }

        public ICollection<Question> GetQuestions()
        {
            var questions = dbContext.Questions
                .Include(q => q.Category)
                .Include(q => q.Answers).ToList();

            for (int i = 0; i < questions.Count; i++)
            {
                questions[i].Answers = questions[i].Answers.OrderBy(a => a.Points).ToList();
            }
            return dbContext.Questions.ToList();
        }

        public ICollection<Question> GetQuestionsRandomOrder()
        {
            var questions = GetQuestions().ToList();
            return Shuffle(questions);
        }

        public Question GetRandomQuestion()
        {
            var questions = GetQuestions().ToList();
            Random rnd = new Random();
            return questions[rnd.Next(questions.Count)];
        }

        private List<T> Shuffle<T>(List<T> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }


    }
}
