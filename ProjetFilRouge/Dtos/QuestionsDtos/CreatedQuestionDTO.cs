namespace ProjetFilRouge.Dtos.QuestionsDtos
{
    public class CreatedQuestionDTO
    {
       public CreatedQuestionDTO() { }
        public CreatedQuestionDTO(string intitule, int idCategory, int idLevel, int idAnswer)
        {
            Intitule = intitule;
            IdCategory = idCategory;
            IdLevel = idLevel;
            IdAnswer = idAnswer;
        }
        public string Intitule { get; set; }
        public int IdCategory { get; set; }
        public int IdLevel { get; set; }
        public int IdAnswer { get; set; }
    }
}