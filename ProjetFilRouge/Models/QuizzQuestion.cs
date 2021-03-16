namespace ProjetFilRouge.Models
{
    public class QuizzQuestion
    {
        public QuizzQuestion()
        {
        }

        public QuizzQuestion(int idQuizz, int idQuestion, string comment, bool? isCorrectAnswer, string answerCandidate = null)
        {
            IdQuizz = idQuizz;
            IdQuestion = idQuestion;
            Comment = comment;
            AnswerCandidate = answerCandidate;
            IsCorrectAnswer = isCorrectAnswer;
        }

        public int? IdQuizz { get; set; }
        public int? IdQuestion { get; set; }
        public string Comment { get; set; }
        public bool? IsCorrectAnswer { get; set; }
        public string AnswerCandidate { get; set; }
    }
}