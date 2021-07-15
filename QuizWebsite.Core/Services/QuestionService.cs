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

            var result = question.Answers.OrderByDescending(a => a.Place).FirstOrDefault(a => IsSimilar(answerRequest.AnswerText, a.AnswerText));
            if (result != null)
            {
                var dto = mapper.Map<AnswerResponseDto>(result);
                return dto;
            }

            return new AnswerResponseDto();
        }

        private bool IsSimilar(string userAnswer, string answer) //userAnswer is what user answered, answer is the real answer
        {
            answer = answer.ToUpper().Replace("THE ", "").Replace("OF ", "")
                .Replace("AND ", "").Replace(".", "").Replace("-", "")
                .Replace("!", "");
            answer = answer.Replace(" THE", "").Replace(" OF", "")
                .Replace(" AND", "").Replace(" ", "");
            userAnswer = userAnswer.ToUpper().Replace("THE ", "").Replace("OF ", "")
                .Replace("AND ", "").Replace(".", "").Replace("-", "")
                .Replace("!", "");
            userAnswer = userAnswer.Replace(" THE", "").Replace(" OF", "")
                .Replace(" AND", "").Replace(" ", "");
            if (answer == userAnswer)
                return true;

            if (answer.Length == userAnswer.Length)
            {
                int count = 0;
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] != userAnswer[i])
                        count++;
                }
                if (count <= 1)
                    return true;
                return false;
            }
            if (answer.Length == userAnswer.Length - 1)
            {
                int count = 0;
                for (int i = 0; i < userAnswer.Length + 1; i++)
                {
                    if (answer.Length != i)
                    {
                        if (answer[i] != userAnswer[i] && count == 0)
                        {
                            userAnswer = userAnswer.Remove(i, 1);
                            count++;
                            if (answer == userAnswer)
                                return true;
                        }
                    }
                    else
                    {
                        userAnswer = userAnswer.Remove(userAnswer.Length - 1, 1);
                        if (answer == userAnswer)
                            return true;
                    }
                }
                if (answer == userAnswer)
                    return true;
                return false;
            }
            if (answer.Length == userAnswer.Length + 1)
            {
                int count = 0;
                for (int i = 0; i < userAnswer.Length; i++)
                {
                    if (userAnswer.Length != i)
                    {
                        if (answer[i] != userAnswer[i])
                        {
                            count++;
                            if (answer[i + 1] != userAnswer[i])
                            {
                                count++;
                            }
                        }
                    }
                }
                if (count <= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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
            question.Answers = question.Answers.OrderBy(e => e.Place).ToList();
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
