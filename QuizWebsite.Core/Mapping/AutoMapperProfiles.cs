using AutoMapper;
using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizWebsite.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<QuestionRequestDto, Question>();
            CreateMap<Question, QuestionResponseDto>()
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.CategoryQuestions
                    .Select(c => new CategoryResponseDto
                    {
                        Id = c.CategoryId,
                        Name = c.Category.Name
                    })));
            CreateMap<Question, QuestionDetailResponseDto>()
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.CategoryQuestions
                    .Select(c => new CategoryResponseDto
                    {
                        Id = c.CategoryId,
                        Name = c.Category.Name
                    })));

            CreateMap<AnswerDetailRequestDto, Answer>();
            CreateMap<AnswerRequestDto, Answer>();
            CreateMap<Answer, AnswerResponseDto>();

            CreateMap<CategoryRequestDto, Category>();
            CreateMap<Category, CategoryResponseDto>();

            CreateMap<RoomRequestDto, Room>();
            CreateMap<Room, RoomResponseDto>();

        }
    }
}
