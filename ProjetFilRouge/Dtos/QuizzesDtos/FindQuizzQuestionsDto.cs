using ProjetFilRouge.Dtos.AnswerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.QuestionsDtos
{
    public class FindQuizzQuestionsDto
    {
        public FindQuizzQuestionsDto(int? idQuestion, string intitule, string category, string level,
                    FindAnswerDto answer, FindAnswerDto candidateAnswer)
        {
            IdQuestion = idQuestion;
            Intitule = intitule;
            Category = category;
            Level = level;
            Answer = answer;
            CandidateAnswer = candidateAnswer;
        }

        public int? IdQuestion { get; set; }
        public string Intitule { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public FindAnswerDto Answer { get; set; }
        public FindAnswerDto CandidateAnswer { get; set; }
    }
}
