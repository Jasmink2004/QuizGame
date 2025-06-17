namespace QuizGame.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Genre { get; set; } = string.Empty; // Option 1: Initialize
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public int CorrectOption { get; set; }
    }

}
