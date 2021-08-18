using AutoMapper;
using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Entities;
using QuizWebsite.Core.Extensions;
using QuizWebsite.Core.Interfaces.Repositories;
using QuizWebsite.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<QuestionDetailResponseDto> AddAsync(QuestionRequestDto questionRequest)
        {
            var questionEntity = mapper.Map<Question>(questionRequest);

            var result = await questionRepository.AddAsync(questionEntity);
            var dto = mapper.Map<QuestionDetailResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await questionRepository.DeleteAsync(id);
        }

        public async Task<QuestionDetailResponseDto> GetByIdAsync(Guid id)
        {
            var result = await questionRepository.GetByIdAsync(id);
            OrderByPlace(result);

            var dto = mapper.Map<QuestionDetailResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<QuestionResponseDto>> ListAllAsync()
        {
            var result = await questionRepository.ListAllAsync();
            OrderByPlace(result);
            var dto = mapper.Map<IEnumerable<QuestionResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<QuestionResponseDto>> ListAllAsyncRandomOrder()
        {
            var result = await questionRepository.ListAllAsync();
            OrderByPlace(result);
            result = Shuffle(result.ToList());
            var dto = mapper.Map<IEnumerable<QuestionResponseDto>>(result);

            return dto;
        }

        public async Task<QuestionDetailResponseDto> UpdateAsync(QuestionRequestDto questionRequest)
        {
            var questionEntity = mapper.Map<Question>(questionRequest);
            var result = await questionRepository.UpdateAsync(questionEntity);
            var dto = mapper.Map<QuestionDetailResponseDto>(result);
            return dto;
        }

        public async Task<AnswerResponseDto> Answer(Guid QuestionId, AnswerRequestDto answerRequest)
        {
            var question = await questionRepository.GetByIdAsync(QuestionId);

            var answer = question.Answers.OrderByDescending(a => a.Place).FirstOrDefault(a => answerRequest.AnswerText.IsSimilar(a.AnswerText));
            var result = question.Answers.Where(a => a.Place == answer?.Place).OrderByDescending(a => a.AnswerText.Length).FirstOrDefault();
            if (result != null)
            {
                var dto = mapper.Map<AnswerResponseDto>(result);
                return dto;
            }

            return new AnswerResponseDto();
        }

        public async Task<IEnumerable<QuestionResponseDto>> SearchByCategoriesAndTypeRandom(string categoryIds, string type)
        {
            var questions = await questionRepository.SearchByCategoryAndType(categoryIds, type);

            OrderByPlace(questions);
            questions = Shuffle(questions.ToList());
            return mapper.Map<IEnumerable<QuestionResponseDto>>(questions);
        }

        public async Task<AnswerResponseDto> Answer(AnswerRequestDto answerRequest, string connectionId)
        {
            var result = await questionRepository.Answer(answerRequest, connectionId);
            if (result != null)
            {
                var dto = mapper.Map<AnswerResponseDto>(result);
                return dto;
            }

            return new AnswerResponseDto();
        }



        private void OrderByPlace(IEnumerable<Question> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                list.ToList()[i].Answers = list.ToList()[i].Answers.OrderBy(e => e.Place).ToList();
            }
        }

        private void OrderByPlace(Question question)
        {
            question.Answers = question.Answers.OrderBy(e => e.Place).ThenByDescending(e => e.AnswerText.Length).ToList();
        }

        private List<Question> Shuffle(List<Question> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

    }
}
