using AutoMapper;
using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizWebsite.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<QuestionRequestDto, Question>();
            CreateMap<Question, QuestionResponseDto>();

            CreateMap<AnswerRequestDto, Answer>();
            CreateMap<Answer, AnswerResponseDto>();

            CreateMap<CategoryRequestDto, Category>();
            CreateMap<Category, CategoryResponseDto>();

        }
    }
}
