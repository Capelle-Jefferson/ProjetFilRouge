using ProjetFilRouge.Models;
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

        public FindAnswerDto(int? idAnswer, string typeAnswer, string explication, string textAnswer,List<ChoiceAnswer> listChoiceAnswer = null )
        {
            IdAnswer = idAnswer;
            TypeAnswer = typeAnswer;
            Explication = explication;
            TextAnswer = textAnswer;
            ListChoiceAnswer = listChoiceAnswer;
        }

        public int? IdAnswer { get; set; }
        public string TypeAnswer { get; set; }
        public string Explication { get; set; }
        public string TextAnswer { get; set; }
        public List<ChoiceAnswer> ListChoiceAnswer { get; set; }
    }
}
