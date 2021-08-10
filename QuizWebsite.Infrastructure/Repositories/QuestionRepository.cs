using Microsoft.EntityFrameworkCore;
using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Entities;
using QuizWebsite.Core.Extensions;
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

        public async Task<IEnumerable<Question>> SearchByCategoryAndType(string categoryIds, string type)
        {
            var questions = await GetAllAsync().ToListAsync();
            if (categoryIds != null && type != null)
            {
                List<Question> filteredQuestions = new List<Question>();
                for (int i = 0; i < questions.Count(); i++)
                {
                    var categories = questions[i].CategoryQuestions.Select(q => q.CategoryId.ToString()).ToList();
                    if (categoryIds.Split('&').Intersect(categories).Any())
                    {
                        filteredQuestions.Add(questions[i]);
                    }
                }
                return filteredQuestions.Where(q => q.QuestionType == type);
            }
            else
            {
                if (categoryIds != null && type == null)
                {
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
                else if (categoryIds == null && type != null)
                {
                    return questions.Where(q => q.QuestionType == type);
                }
                else
                {
                    return questions;
                }
            }
        }

        public async Task<Answer> Answer(AnswerRequestDto answerRequest, string connectionId)
        {
            var player = await _dbContext.Players
                .Include(p => p.Room)
                    .ThenInclude(r => r.RoomQuestions)
                    .ThenInclude(rq => rq.Question)
                    .ThenInclude(q => q.Answers)
                .Include(p => p.Room)
                    .ThenInclude(r =>r.Players)
                .FirstOrDefaultAsync(p => p.ConnectionId == connectionId);
            if (player.Answered == 0)
            {


                var question = player.Room.RoomQuestions.FirstOrDefault(rq => rq.activeQuestion).Question;

                var answer = question.Answers.OrderByDescending(a => a.Place).FirstOrDefault(a => answerRequest.AnswerText.IsSimilar(a.AnswerText));
                var result = question.Answers.Where(a => a.Place == answer?.Place).OrderByDescending(a => a.AnswerText.Length).FirstOrDefault();

                if (result != null)
                {
                    if (!player.Room.Players.Any(p => p.Answered == result.Place))
                    {
                        player.Score += result.Points;
                    }
                }
                else
                {
                    player.Answered = -1;
                }


                await _dbContext.SaveChangesAsync();
                 return result;
            }
            else
            {
                return null;
            }
        }
    }
}
