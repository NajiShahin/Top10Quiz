using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Interfaces.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> SearchByConnectionId(string connectionId);
    }
}
