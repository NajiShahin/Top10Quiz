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
    public class PlayerRepository : EfRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Player> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Player> GetAllAsync()
        {
            return _dbContext.Players
                .Include(p => p.Room)
                    .AsNoTracking();
        }

        public override async Task<Player> DeleteAsync(Guid id)
        {
            var player = await _dbContext.Players.FirstOrDefaultAsync(p => p.Id == id);
            player.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return player;
        }

        public async Task<Player> SearchByConnectionId(string connectionId)
        {
            return await GetAllAsync().FirstOrDefaultAsync(p => p.ConnectionId == connectionId);
        }
    }
}
