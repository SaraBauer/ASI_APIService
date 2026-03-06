using APIService.DTOs;
using APIService.Models;
using APIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{

    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly GameRepository _repo;

        public GameController(GameRepository repo)
        {
            _repo = repo;
        }

        //creates a new game
        [HttpPost]
        public async Task<IActionResult> CreateGame(GameResultDto dto)
        {
            var game = new GameResult
            {
                Range = dto.Range,
                TargetNumber = dto.TargetNumber,
                PlayedAt = dto.PlayedAt
            };

            var id = await _repo.CreateGameAsync(game);
            return Ok(new { GameId = id });
        }

        //update a game with certain id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameResultUpdateDto dto)
        {
            await _repo.UpdateGameAsync(id, dto.Attempts, dto.TimeTaken);
            return NoContent();
        }

        // return all games and guesses from the database
        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _repo.GetAllGamesAsync();

            var dto = games.Select(g => new GameResultWithGuessesDto
            {
                Id = g.Id,
                Range = g.Range,
                TargetNumber = g.TargetNumber,
                Attempts = g.Attempts,
                TimeTaken = g.TimeTaken,
                PlayedAt = g.PlayedAt,
                Guesses = g.Guesses.Select(q => new GuessEntryDto
                {
                    Id = q.Id,
                    Guess = q.Guess,
                    Time = q.Time,
                    GameResultId = q.GameResultId
                }).ToList()
            }).ToList();

            return Ok(dto);
        }
    }
}
