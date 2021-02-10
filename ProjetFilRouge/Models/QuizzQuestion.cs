namespace ProjetFilRouge.Models
{
    public class QuizzQuestion
    {
        public QuizzQuestion()
        {
        }

        public QuizzQuestion(int idQuizz, int idQuestion, string comment, bool? isCorrectAnswer, int? idAnswerCandidate = null)
        {
            IdQuizz = idQuizz;
            IdQuestion = idQuestion;
            Comment = comment;
            IdAnswerCandidate = idAnswerCandidate;
            IsCorrectAnswer = isCorrectAnswer;
        }

        public int? IdQuizz { get; set; }
        public int? IdQuestion { get; set; }
        public string Comment { get; set; }
        public bool? IsCorrectAnswer { get; set; }
        public int? IdAnswerCandidate { get; set; }
    }
}