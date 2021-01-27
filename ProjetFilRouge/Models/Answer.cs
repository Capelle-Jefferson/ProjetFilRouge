using System.Collections.Generic;

namespace ProjetTest.Models
{
    public enum TypeAnswer{
        QCM,
        Text
    }
    public class Answer
    {
        public Answer()
        {
        }

        public Answer(int? idAnswer, TypeAnswer typeAnswer, string explication, string textAnswer)
        {
            IdAnswer = idAnswer;
            TypeAnswer = typeAnswer;
            Explication = explication;
            TextAnswer = textAnswer;
        }

        public int? IdAnswer { get; set; }
        public TypeAnswer TypeAnswer { get; set; }
        public string Explication { get; set; }
        public string TextAnswer { get; set; }
    }
}