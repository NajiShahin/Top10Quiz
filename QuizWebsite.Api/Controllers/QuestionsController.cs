using Microsoft.AspNetCore.Mvc;
using QuizWebsite.Core.Dtos;
using QuizWebsite.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly IQuestionService questionService;
        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string categoryIds, [FromQuery] string type)
        {
            if (categoryIds != null && type != null)
            {
                var questions = await questionService.SearchByCategoriesAndTypeRandom(categoryIds, type);
                if (questions.Any())
                {
                    return Ok(questions);
                }
                return NotFound($"There were no questions found with categorId {categoryIds} with question type {type}");
            }
            else
            {
                if (type == null)
                {
                    var questions = await questionService.SearchByCategoriesAndTypeRandom(categoryIds, type);
                    if (questions.Any())
                    {
                        return Ok(questions);
                    }
                    return NotFound($"There were no questions found with categorId {categoryIds}");
                }
                if (categoryIds == null)
                {
                    var questions = await questionService.SearchByCategoriesAndTypeRandom(categoryIds, type);
                    if (questions.Any())
                    {
                        return Ok(questions);
                    }
                    return NotFound($"There were no questions found with question type {type}");
                }
                else
                {
                    var questions = await questionService.ListAllAsync();
                    return Ok(questions);
                }
            }
        }

        [HttpGet("Randomize")]
        public async Task<IActionResult> GetRandomOrder([FromQuery] string categoryIds, [FromQuery] string type)
        {
            if (categoryIds != null)
            {
                var questions = await questionService.SearchByCategoriesAndTypeRandom(categoryIds, type);
                if (questions.Any())
                {
                    return Ok(questions);
                }
                return NotFound($"There were no questions found with categorId {categoryIds}");
            }
            else
            {
                var questions = await questionService.ListAllAsyncRandomOrder();
                return Ok(questions);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var question = await questionService.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound($"Question with ID {id} does not exist");
            }
            return Ok(question);
        }

        [HttpPost("{id}/answer")]
        public async Task<IActionResult> Answer(Guid id, AnswerRequestDto answerRequest)
        {
            var questionResponseDto = await questionService.Answer(id, answerRequest);
            return Ok(questionResponseDto);
        }

        [HttpPost("{id}/answer/{connectionId}")]
        public async Task<IActionResult> Answer(Guid id, AnswerRequestDto answerRequest, string connectionId)
        {
            var questionResponseDto = await questionService.Answer(id, answerRequest, connectionId);
            return Ok(questionResponseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuestionRequestDto questionRequest)
        {
            var questionResponseDto = await questionService.AddAsync(questionRequest);
            return CreatedAtAction(nameof(Get), new { id = questionResponseDto.Id }, questionResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(QuestionRequestDto questionRequest)
        {
            var questionResponseDto = await questionService.UpdateAsync(questionRequest);
            return Ok(questionResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var questionDto = await questionService.GetByIdAsync(id);
            if (questionDto == null)
            {
                return NotFound($"Question with ID {id} does not exist");
            }
            await questionService.DeleteAsync(id);
            return Ok();
        }
    }
}
