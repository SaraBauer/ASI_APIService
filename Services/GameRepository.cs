using APIService.Data;
using APIService.Models;
using Microsoft.EntityFrameworkCore;

namespace APIService.Services
{
public class GameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        // Saves a new game in the database
        public async Task<int> CreateGameAsync(GameResult game)
        {
            _context.GameResults.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        // Saves adds a guess to list of guesses
        public async Task AddGuessAsync(GuessEntry guess)
        {
            _context.GuessEntries.Add(guess);
            await _context.SaveChangesAsync();
        }

        //updates game, saves new guesses with foreign key relation to existing game (if found in db)
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

        //returns all games found in db
        public async Task<List<GameResult>> GetAllGamesAsync()
        {
            return await _context.GameResults
                .Include(g => g.Guesses)
                .OrderByDescending(g => g.PlayedAt)
                .ToListAsync();
        }
    }
}
