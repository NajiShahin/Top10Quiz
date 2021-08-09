using AutoMapper;
using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Entities;
using QuizWebsite.Core.Interfaces.Repositories;
using QuizWebsite.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        public RoomService(IRoomRepository roomRepository,
            IMapper mapper,
            IQuestionRepository questionRepository)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
            this.questionRepository = questionRepository;
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
            var roomQuestion = result.RoomQuestions?.FirstOrDefault(r => r.activeQuestion);
            var question = await questionRepository.GetByIdAsync(roomQuestion.QuestionId);
            var roomQuestionDto = mapper.Map<QuestionResponseDto>(question);
            dto.Question = new List<QuestionResponseDto>();
            dto.Question.Add(roomQuestionDto);
            return dto;
        }

        public async Task<RoomResponseDto> JoinPublicRoom(string connectionId)
        {
            var result = await roomRepository.JoinPublicRoom(connectionId);
            var dto = mapper.Map<RoomResponseDto>(result);
            return dto;
        }

        public async Task<RoomResponseDto> LeavePublicRoom(string connectionId)
        {
            var result = await roomRepository.LeavePublicRoom(connectionId);
            var dto = mapper.Map<RoomResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<RoomResponseDto>> ListAllAsync()
        {
            var result = await roomRepository.ListAllAsync();
            var dto = mapper.Map<IEnumerable<RoomResponseDto>>(result);
            foreach (var item in dto)
            {
                var roomQuestions = result.ToList().FirstOrDefault(r => r.Id == item.Id).RoomQuestions;
                var roomQuestion = roomQuestions?.FirstOrDefault(r => r.activeQuestion);
                var question = await questionRepository.GetByIdAsync(roomQuestion.QuestionId);
                var roomQuestionDto = mapper.Map<QuestionResponseDto>(question);
                item.Question = new List<QuestionResponseDto>();
                item.Question.Add(roomQuestionDto);
            }
            return dto;
        }

        public async Task<ReadyResponseDto> MakePlayerReady(string connectionId)
        {
            var result = await roomRepository.MakePlayerReady(connectionId);
            return result;
        }

        public async Task<RoomResponseDto> SearchByName(string name)
        {
            var result = await roomRepository.SearchByName(name);
            var dto = mapper.Map<RoomResponseDto>(result);
            var roomQuestion = result?.RoomQuestions?.FirstOrDefault(r => r.activeQuestion);
            var question = await questionRepository.GetByIdAsync(roomQuestion.QuestionId);
            var roomQuestionDto = mapper.Map<QuestionResponseDto>(question);
            dto.Question = new List<QuestionResponseDto>();
            dto.Question.Add(roomQuestionDto);
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
