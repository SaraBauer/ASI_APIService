using Microsoft.AspNetCore.Mvc;
using APIService.DTOs;
using APIService.Models;
namespace APIService.Controllers
{


    [ApiController]
    [Route("api/guess")]
    public class GuessController : ControllerBase
    {
        private readonly GameRepository _repo;

        public GuessController(GameRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddGuess(GuessEntryDto dto)
        {
            var guess = new GuessEntry
            {
                Guess = dto.Guess,
                Time = dto.Time,
                GameResultId = dto.GameResultId
            };

            await _repo.AddGuessAsync(guess);
            return Ok();
        }
    }

}
