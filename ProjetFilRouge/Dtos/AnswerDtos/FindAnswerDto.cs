using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.AnswerDtos
{
    public class FindAnswerDto
    {
        public FindAnswerDto()
        {
        }

        public FindAnswerDto(int? idAnswer, Models.TypeAnswer typeAnswer, string explication, string textAnswer)
        {
            IdAnswer = idAnswer;
            TypeAnswer = typeAnswer;
            Explication = explication;
            TextAnswer = textAnswer;
        }

        public int? IdAnswer { get; set; }
        public Models.TypeAnswer TypeAnswer { get; set; }
        public string Explication { get; set; }
        public string TextAnswer { get; set; }
    }
}
