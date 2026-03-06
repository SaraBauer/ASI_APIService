using APIService.Models;
using Microsoft.EntityFrameworkCore;

namespace APIService.Data
{

    public class GameDbContext : DbContext
    {
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<GuessEntry> GuessEntries { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options) { }

        //establishes the FK relationship in one to many way between gameresult and Guesses
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<GameResult>()
                .HasMany(g => g.Guesses)
                .WithOne(g => g.GameResult)
                .HasForeignKey(g => g.GameResultId).OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
