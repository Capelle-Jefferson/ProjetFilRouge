using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.QuestionsDtos
{
    public class FindQuestionsDto
    {
        public FindQuestionsDto(int? idQuestion, string intitule, int? idCategory, int? idLevel, int? idAnswer)
        {
            IdQuestion = idQuestion;
            Intitule = intitule;
            IdCategory = idCategory;
            IdLevel = idLevel;
            IdAnswer = idAnswer;
        }

        public int? IdQuestion { get; set; }
        public string Intitule { get; set; }
        public int? IdCategory { get; set; }
        public int? IdLevel { get; set; }
        public int? IdAnswer { get; set; }
    }
}
