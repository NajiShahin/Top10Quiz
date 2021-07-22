using QuizWebsite.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Interfaces.Services
{
    public interface IRoomService 
    {
        Task<IEnumerable<RoomResponseDto>> ListAllAsync();
        Task<RoomResponseDto> JoinPublicRoom();
        Task<RoomResponseDto> LeavePublicRoom(Guid Id);
        Task<RoomResponseDto> GetByIdAsync(Guid id);
        Task<RoomResponseDto> AddAsync(RoomRequestDto roomRequest);
        Task<RoomResponseDto> UpdateAsync(RoomResponseDto roomRequest);
        Task DeleteAsync(Guid id);
    }
}
