namespace QuizGame.Models
{
    public class QuizViewModel
    {
        public string Genre { get; set; } = string.Empty;
        public List<QuizQuestion> Questions { get; set; } = new();
        public int CurrentQuestionIndex { get; set; }
        public int Score { get; set; }
        public List<int> UserAnswers { get; set; } = new();
    }
}
