using AutoMapper;
using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Entities;
using QuizWebsite.Core.Interfaces.Repositories;
using QuizWebsite.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IMapper mapper;
        public PlayerService(IPlayerRepository playerRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.playerRepository = playerRepository;
        }

        public async Task<PlayerResponseDto> AddAsync(PlayerRequestDto playerRequest)
        {
            var player = mapper.Map<Player>(playerRequest);

            var result = await playerRepository.AddAsync(player);
            var dto = mapper.Map<PlayerResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await playerRepository.DeleteAsync(id);
        }

        public async Task<PlayerResponseDto> GetByIdAsync(Guid id)
        {
            var result = await playerRepository.GetByIdAsync(id);
            var dto = mapper.Map<PlayerResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<PlayerResponseDto>> ListAllAsync()
        {
            var result = await playerRepository.ListAllAsync();
            var dto = mapper.Map<IEnumerable<PlayerResponseDto>>(result);
            return dto;
        }

        public async Task<PlayerResponseDto> UpdateAsync(PlayerRequestDto playerRequest)
        {
            var player = mapper.Map<Player>(playerRequest);
            var result = await playerRepository.UpdateAsync(player);
            var dto = mapper.Map<PlayerResponseDto>(result);
            return dto;
        }
    }
}
