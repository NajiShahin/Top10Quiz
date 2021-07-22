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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public RoomService(IRoomRepository roomRepository,
            IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }
        public async Task<RoomResponseDto> AddAsync(RoomRequestDto roomRequest)
        {
            var roomEntity = mapper.Map<Room>(roomRequest);

            var result = await roomRepository.AddAsync(roomEntity);
            var dto = mapper.Map<RoomResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await roomRepository.DeleteAsync(id);
        }

        public async Task<RoomResponseDto> GetByIdAsync(Guid id)
        {
            var result = await roomRepository.GetByIdAsync(id);
            var dto = mapper.Map<RoomResponseDto>(result);
            return dto;
        }

        public async Task<RoomResponseDto> JoinPublicRoom()
        {
            var result = await roomRepository.JoinPublicRoom();
            var dto = mapper.Map<RoomResponseDto>(result);
            return dto;
        }

        public async Task<RoomResponseDto> LeavePublicRoom(Guid Id)
        {
            var result = await roomRepository.LeavePublicRoom(Id);
            var dto = mapper.Map<RoomResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<RoomResponseDto>> ListAllAsync()
        {
            var result = await roomRepository.ListAllAsync();
            var dto = mapper.Map<IEnumerable<RoomResponseDto>>(result);
            return dto;
        }

        public async Task<RoomResponseDto> UpdateAsync(RoomResponseDto roomRequest)
        {
            var roomEntity = mapper.Map<Room>(roomRequest);
            var result = await roomRepository.UpdateAsync(roomEntity);
            var dto = mapper.Map<RoomResponseDto>(result);
            return dto;
        }
    }
}
