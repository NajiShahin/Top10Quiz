using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Entities;
using QuizWebsite.Core.Interfaces.Repositories;
using QuizWebsite.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Infrastructure.Repositories
{
    public class QuestionRepository : EfRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Question> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Question> GetAllAsync()
        {
            return _dbContext.Questions.AsNoTracking()
                .Include(q => q.Answers)
                .Include(q => q.CategoryQuestions)
                    .ThenInclude(cq => cq.Category)
                .AsNoTracking();
        }

        public async Task<IEnumerable<Question>> SearchByCategories(string categoryIds)
        {
            var questions = await GetAllAsync().ToListAsync();
            List<Question> filteredQuestions = new List<Question>();
            for (int i = 0; i < questions.Count(); i++)
            {
                var categories = questions[i].CategoryQuestions.Select(q => q.CategoryId.ToString()).ToList();
                if (categoryIds.Split('&').Intersect(categories).Any())
                {
                    filteredQuestions.Add(questions[i]);
                }
            }
            return filteredQuestions;
        }
    }
}
