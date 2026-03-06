using APIService.Data;
using Microsoft.EntityFrameworkCore;

namespace APIService.Models
{
public class GameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateGameAsync(GameResult game)
        {
            _context.GameResults.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public async Task AddGuessAsync(GuessEntry guess)
        {
            _context.GuessEntries.Add(guess);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(int id, int attempts, TimeSpan timeTaken)
        {
            var game = await _context.GameResults.FindAsync(id);
            if (game != null)
            {
                game.Attempts = attempts;
                game.TimeTaken = timeTaken;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GameResult>> GetAllGamesAsync()
        {
            return await _context.GameResults
                .Include(g => g.Guesses)
                .OrderByDescending(g => g.PlayedAt)
                .ToListAsync();
        }
    }

}
