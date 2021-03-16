using System.Collections.Generic;

namespace ProjetFilRouge.Models
{
    public class Question
    {
        public Question()
        {
        }

        public Question(int? idQuestion, string intitule, int idCategory, int idLevel, int idAnswer)
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