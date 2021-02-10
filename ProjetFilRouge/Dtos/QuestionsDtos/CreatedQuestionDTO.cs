using ProjetFilRouge.Dtos.AnswerDtos;

namespace ProjetFilRouge.Dtos.QuestionsDtos
{
    public class CreatedQuestionDTO
    {
       public CreatedQuestionDTO() { }
        public CreatedQuestionDTO(string intitule, int idCategory, int idLevel, CreateAnswerDto answer)
        {
            Intitule = intitule;
            IdCategory = idCategory;
            IdLevel = idLevel;
            Answer = answer;
        }
        public string Intitule { get; set; }
        public int IdCategory { get; set; }
        public int IdLevel { get; set; }
        public CreateAnswerDto Answer { get; set; }
    }
}