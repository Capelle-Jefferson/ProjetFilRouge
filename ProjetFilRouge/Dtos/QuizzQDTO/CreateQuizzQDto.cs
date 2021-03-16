using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.QuizzQDTO
{
    public class CreateQuizzQDto

    {
        public CreateQuizzQDto (){}

        public CreateQuizzQDto(int idQuizz, int idQuestion, string comment, string answerCandidate = null)
        {
            IdQuizz = idQuizz;
            IdQuestion = idQuestion;
            Comment = comment;
            AnswerCandidate = answerCandidate;
        }

        public int? IdQuizz { get; set; }
        public int? IdQuestion { get; set; }
        public string Comment { get; set; }
        public string AnswerCandidate { get; set; }
    }
}
