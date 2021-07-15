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
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Category> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Category> GetAllAsync()
        {
            return _dbContext.Categories.AsNoTracking();
        }

    }
}
