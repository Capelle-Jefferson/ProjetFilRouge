using ProjetFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.AnswerDtos
{
    public class FindAnswerCandidateDto
    {
        public FindAnswerCandidateDto()
        {
        }

        public FindAnswerCandidateDto(int? idAnswer, string typeAnswer, string explication,List<FindChoiceAnswerCandidateDto> listChoiceAnswer = null )
        {
            IdAnswer = idAnswer;
            TypeAnswer = typeAnswer;
            Explication = explication;
            ListChoiceAnswer = listChoiceAnswer;
        }

        public int? IdAnswer { get; set; }
        public string TypeAnswer { get; set; }
        public string Explication { get; set; }
        public List<FindChoiceAnswerCandidateDto> ListChoiceAnswer { get; set; }
    }
}
