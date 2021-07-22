using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> JoinPublicRoom();
        Task<Room> LeavePublicRoom(Guid Id);
        Task<Room> SearchByName(string name);
    }
}
