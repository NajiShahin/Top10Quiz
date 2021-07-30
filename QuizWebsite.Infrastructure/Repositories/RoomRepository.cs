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

        public async Task<Room> JoinPublicRoom(string connectionid)
        {
            var room = GetAllAsync().FirstOrDefault(r => r.Players.Count < maxPeople && r.Public);
            var player = _dbContext.Players.FirstOrDefault(p => p.ConnectionId == connectionid);
            if (room == null)
            {
                room = new Room()
                {
                    Public = true,
                    Name = RandomString(12)
                };
                room.Players.Add(player);
                await AddAsync(room);
            }
            else
            {
                room.Players.Add(player);
                await UpdateAsync(room);
            }
            return room;
        }

        public async Task<Room> LeavePublicRoom(string connectionid)
        {
            var room = GetAllAsync().FirstOrDefault(r => r.Players.Any(a => a.ConnectionId == connectionid));
            if (room != null)
            {
                var player = GetAllAsync()
                    .FirstOrDefault(p => p.Players.Any(a => a.ConnectionId == connectionid))
                    .Players.FirstOrDefault(p => p.ConnectionId == connectionid);
                room.Players.Remove(player);
                if (room?.Players.Count == 0)
                {
                    await DeleteAsync(room);
                }
                else
                {
                    await UpdateAsync(room);
                }
                return room;
            }
            return null;
        }
        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<Room> SearchByName(string name)
        {
            return await GetAllAsync().FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
