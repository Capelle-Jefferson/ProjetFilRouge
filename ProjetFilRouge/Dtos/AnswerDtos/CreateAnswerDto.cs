using ProjetFilRouge.Models;
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

        public CreateAnswerDto(string typeAnswer, string explication, string textAnswer, List<CreateChoiceAnswerDto> listChoiceAnswer)
        {
            TypeAnswer = typeAnswer;
            Explication = explication;
            TextAnswer = textAnswer;
            ListChoiceAnswer = listChoiceAnswer;
        }

        public string TypeAnswer { get; set; }
        public string Explication { get; set; }
        public string TextAnswer { get; set; }

        public List<CreateChoiceAnswerDto> ListChoiceAnswer { get; set; }
    }
}
