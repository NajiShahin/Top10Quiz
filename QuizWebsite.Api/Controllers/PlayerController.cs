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
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var player = await playerService.ListAllAsync();
            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var player = await playerService.GetByIdAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} does not exist");
            }
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PlayerRequestDto playerRequest)
        {
            var playerResponseDto = await playerService.AddAsync(playerRequest);
            return CreatedAtAction(nameof(Get), new { id = playerResponseDto.ConnectionId }, playerResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PlayerRequestDto playerRequest)
        {
            var playerResponseDto = await playerService.UpdateAsync(playerRequest);
            return Ok(playerResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var playerDto = await playerService.GetByIdAsync(id);
            if (playerDto == null)
            {
                return NotFound($"Players with ID {id} does not exist");
            }
            await playerService.DeleteAsync(id);
            return Ok();
        }
    }
}
