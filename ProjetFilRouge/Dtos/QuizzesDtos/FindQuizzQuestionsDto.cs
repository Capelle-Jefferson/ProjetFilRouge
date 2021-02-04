using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.QuestionsDtos
{
    public class FindQuizzQuestionsDto
    {
        public FindQuizzQuestionsDto(int? idQuestion, string intitule, int? idCategory, int? idLevel, int? idAnswer, int? idAnswerCandidate)
        {
            IdQuestion = idQuestion;
            Intitule = intitule;
            IdCategory = idCategory;
            IdLevel = idLevel;
            IdAnswer = idAnswer;
            IdCandidatesAnswer = idAnswerCandidate;
        }

        public int? IdQuestion { get; set; }
        public string Intitule { get; set; }
        public int? IdCategory { get; set; }
        public int? IdLevel { get; set; }
        public int? IdAnswer { get; set; }
        public int? IdCandidatesAnswer { get; set; }
    }
}
