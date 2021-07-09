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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var questions = await questionService.ListAllAsync();
            return Ok(questions);
        }

        [HttpGet("Randomize")]
        public async Task<IActionResult> GetRandomOrder()
        {
            var questions = await questionService.ListAllAsyncRandomOrder();
            return Ok(questions);
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
