using Microsoft.AspNetCore.Mvc;
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
    }
}
