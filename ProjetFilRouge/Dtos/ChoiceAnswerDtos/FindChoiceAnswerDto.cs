namespace ProjetFilRouge.Models
{
    public class FindChoiceAnswerCandidateDto
    {
        public FindChoiceAnswerCandidateDto()
        {
        }

        public FindChoiceAnswerCandidateDto(int? idChoiceAnswer, string textChoice)
        {
            IdChoiceAnswer = idChoiceAnswer;
            TextAnswer = textChoice;
        }

        public int? IdChoiceAnswer { get; set;  }
        public string TextAnswer { get; set;  }
    }
}