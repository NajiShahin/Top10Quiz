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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CategoryResponseDto>> ListAllAsync()
        {
            var result = await categoryRepository.ListAllAsync();
            var dto = mapper.Map<IEnumerable<CategoryResponseDto>>(result);
            return dto;
        }
    }
}
