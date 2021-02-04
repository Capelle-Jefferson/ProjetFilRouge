namespace ProjetFilRouge.Models
{
    public class CreateChoiceAnswerDto
    {
        public CreateChoiceAnswerDto()
        {
        }

        public CreateChoiceAnswerDto(string textChoice, bool isAnswer, int idAnswer)
        {
            TextChoice = textChoice;
            IsAnswer = isAnswer;
            IdAnswer = idAnswer;
        }

        public string TextChoice { get; set; }
        public bool IsAnswer { get; set; }
        public int? IdAnswer { get; set; }
    }
}