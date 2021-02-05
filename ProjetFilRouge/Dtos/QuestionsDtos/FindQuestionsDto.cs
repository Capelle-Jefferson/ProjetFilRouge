using ProjetFilRouge.Dtos.AnswerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.QuestionsDtos
{
    public class FindQuestionsDto
    {
        public FindQuestionsDto(int? idQuestion, string intitule, string category, string level, FindAnswerDto answer)
        {
            IdQuestion = idQuestion;
            Intitule = intitule;
            Category = category;
            Level = level;
            Answer = answer;
        }

        public int? IdQuestion { get; set; }
        public string Intitule { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public FindAnswerDto Answer {get; set;}
    }
}
