namespace ProjetFilRouge.Models
{
    public class ChoiceAnswer
    {
        public ChoiceAnswer()
        {
        }

        public ChoiceAnswer(int? idChoiceAnswer, string textChoice, bool isAnswer, int idAnswer)
        {
            IdChoiceAnswer = idChoiceAnswer;
            TextAnswer = textChoice;
            IsAnswer = isAnswer;
            IdAnswer = idAnswer;
        }

        public int? IdChoiceAnswer { get; set;  }
        public string TextAnswer { get; set;  }
        public bool IsAnswer { get; set;  }
        public int? IdAnswer { get; set; }
    }
}