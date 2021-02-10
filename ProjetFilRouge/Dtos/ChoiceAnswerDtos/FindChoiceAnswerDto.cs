namespace ProjetFilRouge.Models
{
    public class FindChoiceAnswerDto
    {
        public FindChoiceAnswerDto()
        {
        }

        public FindChoiceAnswerDto(int? idChoiceAnswer, string textChoice, bool isAnswer)
        {
            IdChoiceAnswer = idChoiceAnswer;
            TextAnswer = textChoice;
            IsAnswer = isAnswer;
        }

        public int? IdChoiceAnswer { get; set;  }
        public string TextAnswer { get; set;  }
        public bool IsAnswer { get; set;  }
    }
}