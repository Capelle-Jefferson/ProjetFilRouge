using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.QuestionsDtos
{
    public class FindQuestionsDto
    {
        public FindQuestionsDto(int? idQuestion, string intitule, string category, string level, int? idAnswer)
        {
            IdQuestion = idQuestion;
            Intitule = intitule;
            Category = category;
            Level = level;
            IdAnswer = idAnswer;
        }

        public int? IdQuestion { get; set; }
        public string Intitule { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public int? IdAnswer { get; set; }
    }
}
