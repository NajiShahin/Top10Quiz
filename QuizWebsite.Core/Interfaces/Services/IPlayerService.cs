using QuizWebsite.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerResponseDto>> ListAllAsync();
        Task<PlayerResponseDto> GetByIdAsync(Guid id);
        Task<PlayerResponseDto> AddAsync(PlayerRequestDto playerRequest);
        Task<PlayerResponseDto> UpdateAsync(PlayerRequestDto playerRequest);
        Task DeleteAsync(Guid id);
    }
}
