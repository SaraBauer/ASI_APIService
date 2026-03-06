namespace APIService.DTOs
{
    public class GameResultWithGuessesDto
    {
        public int Id { get; set; }
        public int Range { get; set; }
        public int TargetNumber { get; set; }
        public int Attempts { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public DateTime PlayedAt { get; set; }
        public List<GuessEntryDto> Guesses { get; set; }
    }

}
