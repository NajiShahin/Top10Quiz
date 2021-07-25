using AutoMapper;
using QuizWebsite.Core.Dtos;
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

        public Task<PlayerResponseDto> AddAsync(PlayerRequestDto roomRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerResponseDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlayerResponseDto>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerResponseDto> UpdateAsync(PlayerRequestDto roomRequest)
        {
            throw new NotImplementedException();
        }
    }
}
