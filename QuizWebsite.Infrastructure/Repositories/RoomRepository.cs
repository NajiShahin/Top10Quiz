using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizWebsite.Core.Dtos;
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
        int questionAmount = 10;
        private static readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private readonly IServiceProvider ServiceProvider;
        private readonly IServiceScopeFactory serviceFactory;

        public RoomRepository(ApplicationDbContext dbContext, IServiceProvider ServiceProvider, IServiceScopeFactory serviceFactory) : base(dbContext)
        {
            this.ServiceProvider = ServiceProvider;
            this.serviceFactory = serviceFactory;
        }

        public override async Task<Room> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }
        public override IQueryable<Room> GetAllAsync()
        {
            return _dbContext.Rooms.AsNoTracking()
                .Include(r => r.Players)
                .Include(r => r.RoomQuestions)
                    .ThenInclude(rq => rq.Question);
        }

        public async Task<Room> JoinPublicRoom(string connectionid)
        {
            var room = GetAllAsync().FirstOrDefault(r => r.Players.Count < maxPeople && r.Public && r.Done == false);
            var player = _dbContext.Players.FirstOrDefault(p => p.ConnectionId == connectionid);
            if (player == null)
                return null;
            if (room == null)
            {
                room = new Room()
                {
                    Public = true,
                    Players = new List<Player>(),
                    Name = RandomString(12),
                    QuestionAmount = questionAmount,
                };
                room.RoomQuestions = GetRoomQuestions(room);
                var question = room.RoomQuestions.FirstOrDefault(rq => rq.QuestionNumber == room.RoomQuestions.Min(rq => rq.QuestionNumber));
                question.activeQuestion = true;
                player.Room = room;
                player.ColorCode = GetAvailableColor(room);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                if (room.Players == null)
                {
                    room.Players = new List<Player>();
                }
                player.RoomId = room.Id;
                player.ColorCode = GetAvailableColor(room);
                await _dbContext.SaveChangesAsync();
            }

            _timer.Interval = 1000;
            _timer.Elapsed += async (sender, e) => await TimerElapsedAsync(sender, e, room);
            _timer.Start();

            return room;
        }

        async Task TimerElapsedAsync(object sender, System.Timers.ElapsedEventArgs e, Room room)
        {
            var scope = serviceFactory.CreateScope();
            await using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
            var players = await dbContext.Players.Where(p => p.RoomId == room.Id).ToListAsync();
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Answered = 0;
            }
            var oldQuestion = await dbContext.RoomQuestions.FirstOrDefaultAsync(rq => rq.RoomId == room.Id && rq.activeQuestion);
            if (oldQuestion != null)
            {
                oldQuestion.activeQuestion = false;

                if (oldQuestion.QuestionNumber == room.QuestionAmount)
                {
                    dbContext.Rooms.FirstOrDefault(r => r.Id == room.Id).Done = true;
                    _timer.Stop();
                }
                else
                {
                    var newQuestion = await dbContext.RoomQuestions.FirstOrDefaultAsync(rq => rq.QuestionNumber == oldQuestion.QuestionNumber + 1 && rq.RoomId == room.Id);
                    newQuestion.activeQuestion = true;
                }
            }
            await dbContext.SaveChangesAsync();

        }

        public async Task<Room> LeavePublicRoom(string connectionid)
        {
            var room = GetAllAsync().FirstOrDefault(r => r.Players.Any(a => a.ConnectionId == connectionid));
            if (room != null)
            {
                var player = GetAllAsync()
                    .FirstOrDefault(p => p.Players.Any(a => a.ConnectionId == connectionid))
                    .Players.FirstOrDefault(p => p.ConnectionId == connectionid);
                _dbContext.Remove(player);
                await _dbContext.SaveChangesAsync();
                return room;
            }
            return null;
        }

        public async Task<Room> SearchByName(string name)
        {
            return await GetAllAsync().FirstOrDefaultAsync(r => r.Name == name);
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string GetAvailableColor(Room room)
        {
            List<string> colors = new List<string>()
            {
                "#ff2b2b",
                "#7cff2b","#2bffff","#aa2bff","#ff2b87","#ffd82b"
            };
            foreach (var player in room.Players)
            {
                colors.Remove(player.ColorCode);
            }
            Random rnd = new Random();
            return colors[rnd.Next(colors.Count)];
        }

        private List<RoomQuestions> GetRoomQuestions(Room room)
        {
            var roomQuestions = new List<RoomQuestions>();
            var questions = _dbContext.Questions.ToList();
            questions = Shuffle(questions);
            for (int i = 0; i < room.QuestionAmount; i++)
            {
                roomQuestions.Add(
                    new RoomQuestions
                    {
                        Room = room,
                        Question = questions[i],
                        QuestionNumber = i + 1
                    }
                    );
            }
            return roomQuestions;
        }

        private List<Question> Shuffle(List<Question> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

    }
}
