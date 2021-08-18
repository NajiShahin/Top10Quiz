using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> JoinPublicRoom(string connectionId);
        Task<Room> LeavePublicRoom(string connectionId);
        Task<Room> SearchByName(string name);
    }
}
