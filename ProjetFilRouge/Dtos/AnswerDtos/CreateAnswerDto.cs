using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.AnswerDtos
{
    public class CreateAnswerDto
    {
        public CreateAnswerDto()
        {
        }

        public CreateAnswerDto(Models.TypeAnswer typeAnswer, string explication, string textAnswer)
        {
            TypeAnswer = typeAnswer;
            Explication = explication;
            TextAnswer = textAnswer;
        }

        public Models.TypeAnswer TypeAnswer { get; set; }
        public string Explication { get; set; }
        public string TextAnswer { get; set; }
    }
}
