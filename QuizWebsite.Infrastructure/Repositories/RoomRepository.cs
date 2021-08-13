using Microsoft.EntityFrameworkCore;
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
        public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
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

        public async Task<ReadyResponseDto> MakePlayerReady(string connectionId)
        {
            var player = await _dbContext.Players.Include(p => p.Room).FirstOrDefaultAsync(p => p.ConnectionId == connectionId);
            var room = await GetAllAsync()
                .FirstOrDefaultAsync(r => r.Id == player.RoomId);
            if (player.Ready || room == null)
                return null;
            player.Ready = true;
            var amountOfReadyUsers = room.Players.Where(p => p.Ready).Count() + 1;
            var amountOfUsers = room.Players.Count;

            if (amountOfReadyUsers == amountOfUsers)
            {

                var players = await _dbContext.Players.Where(p => p.RoomId == room.Id).ToListAsync();
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].Ready = false;
                    players[i].Answered = 0;
                }
                var oldQuestion = await _dbContext.RoomQuestions.FirstOrDefaultAsync(rq => rq.RoomId == room.Id && rq.activeQuestion);
                if (oldQuestion != null)
                {
                    oldQuestion.activeQuestion = false;
                }
                if (oldQuestion.QuestionNumber == room.QuestionAmount)
                {
                    room.Done = true;
                }
                else
                {
                    var newQuestion = await _dbContext.RoomQuestions.FirstOrDefaultAsync(rq => rq.QuestionNumber == oldQuestion.QuestionNumber + 1 && rq.RoomId == room.Id);
                    newQuestion.activeQuestion = true;
                }
            }

            var readyResponse = new ReadyResponseDto()
            {
                AmountOfReadyUsers = amountOfReadyUsers,
                AmountOfUsers = amountOfUsers
            };

            await _dbContext.SaveChangesAsync();

            return readyResponse;
        }
    }
}
