using QuizWebsite.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebsite.Core.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionResponseDto>> ListAllAsync();
        Task<IEnumerable<QuestionResponseDto>> ListAllAsyncRandomOrder();
        Task<QuestionResponseDto> GetByIdAsync(Guid id);
        Task<QuestionResponseDto> AddAsync(QuestionRequestDto questionRequest);
        Task<QuestionResponseDto> UpdateAsync(QuestionRequestDto questionRequest);
        Task DeleteAsync(Guid id);
    }
}
