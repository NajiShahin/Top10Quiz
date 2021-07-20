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
    public class RoomsController : Controller
    {
        private readonly IRoomService roomService;
        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var question = await roomService.ListAllAsync();
            return Ok(question);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var question = await roomService.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound($"Room with ID {id} does not exist");
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoomRequestDto roomRequest)
        {
            var questionResponseDto = await roomService.AddAsync(roomRequest);
            return CreatedAtAction(nameof(Get), new { id = questionResponseDto.Id }, questionResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RoomRequestDto roomRequest)
        {
            var questionResponseDto = await roomService.UpdateAsync(roomRequest);
            return Ok(questionResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var questionDto = await roomService.GetByIdAsync(id);
            if (questionDto == null)
            {
                return NotFound($"Rooms with ID {id} does not exist");
            }
            await roomService.DeleteAsync(id);
            return Ok();
        }
    }
}
