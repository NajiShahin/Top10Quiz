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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        public QuestionService(IQuestionRepository questionRepository,
            IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        public async Task<QuestionResponseDto> AddAsync(QuestionRequestDto questionRequest)
        {
            var questionEntity = mapper.Map<Question>(questionRequest);

            var result = await questionRepository.AddAsync(questionEntity);
            var dto = mapper.Map<QuestionResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await questionRepository.DeleteAsync(id);
        }

        public async Task<QuestionResponseDto> GetByIdAsync(Guid id)
        {
            var result = await questionRepository.GetByIdAsync(id);

            var dto = mapper.Map<QuestionResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<QuestionResponseDto>> ListAllAsync()
        {
            var result = await questionRepository.ListAllAsync();
            var dto = mapper.Map<IEnumerable<QuestionResponseDto>>(result);
            return dto;
        }

        public async Task<QuestionResponseDto> UpdateAsync(QuestionRequestDto questionRequest)
        {
            var questionEntity = mapper.Map<Question>(questionRequest);
            var result = await questionRepository.UpdateAsync(questionEntity);
            var dto = mapper.Map<QuestionResponseDto>(result);
            return dto;
        }
    }
}
