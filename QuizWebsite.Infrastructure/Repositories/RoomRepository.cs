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
    public class RoomRepository : EfRepository<Room>, IRoomRepository
    {
        int maxPeople = 6;
        public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Room> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Room> GetAllAsync()
        {
            return _dbContext.Rooms.AsNoTracking();
        }

        public async Task<Room> JoinPublicRoom()
        {
            var room = GetAllAsync().FirstOrDefault(r => r.Players < maxPeople && r.Public);
            room.Players++;
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<Room> LeavePublicRoom(Guid Id)
        {
            var room = GetAllAsync().FirstOrDefault(r => r.Id == Id);
            room.Players++;
            await _dbContext.SaveChangesAsync();
            return room;
        }
    }
}
