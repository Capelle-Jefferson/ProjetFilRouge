using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.QuizzQDTO
{
    public class CreateQuizzQDto

    {
        public CreateQuizzQDto (){}

        public CreateQuizzQDto(int idQuizz, int idQuestion, string comment, int? idAnswerCandidate = null)
        {
            IdQuizz = idQuizz;
            IdQuestion = idQuestion;
            Comment = comment;
            IdAnswerCandidate = idAnswerCandidate;
        }

        public int? IdQuizz { get; set; }
        public int? IdQuestion { get; set; }
        public string Comment { get; set; }
        public int? IdAnswerCandidate { get; set; }
    }
}
