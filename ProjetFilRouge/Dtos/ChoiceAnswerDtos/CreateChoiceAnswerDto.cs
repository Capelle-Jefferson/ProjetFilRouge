namespace ProjetFilRouge.Models
{
    public class CreateChoiceAnswerDto
    {
        public CreateChoiceAnswerDto()
        {
        }

        public CreateChoiceAnswerDto(string textChoice, bool isAnswer)
        {
            TextAnswer = textChoice;
            IsAnswer = isAnswer;
        }

        public string TextAnswer { get; set; }
        public bool IsAnswer { get; set; }
    }
}