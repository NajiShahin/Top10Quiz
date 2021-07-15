﻿using QuizWebsite.Core.Dtos;
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
        Task<QuestionDetailResponseDto> GetByIdAsync(Guid id);
        Task<QuestionDetailResponseDto> AddAsync(QuestionRequestDto questionRequest);
        Task<QuestionDetailResponseDto> UpdateAsync(QuestionRequestDto questionRequest);
        Task DeleteAsync(Guid id);
        Task<AnswerResponseDto> Answer(Guid QuestionId,AnswerRequestDto answerRequest);
        Task<IEnumerable<QuestionResponseDto>> SearchByCategories(string categoryIds); //Seperated by '&'
        Task<IEnumerable<QuestionResponseDto>> SearchByCategoriesRandomOrder(string categoryIds); //Seperated by '&'
    }
}
