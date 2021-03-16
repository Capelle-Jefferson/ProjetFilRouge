using ProjetFilRouge.Dtos.QuestionsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class FindQuizzCandidateDto
    {
        public int? idQuizz { get; set; }
        public string codeQuizz { get; set; }
        public DateTime? date { get; set; }
        public string category { get; set; }
        public string level { get; set; }
        public int? idUser { get; set; }
        public int? idCandidat { get; set; }

        public List<FindQuizzQuestionCandidateDto> Questions { get; set; }

        public FindQuizzCandidateDto(int? idQuizz, string codeQuizz, DateTime? date, string category, string level, int? idUser, int? idCandidat, List<FindQuizzQuestionCandidateDto> Questions)
        {
            this.idQuizz = idQuizz;
            this.codeQuizz = codeQuizz;
            this.date = date;
            this.category = category;
            this.level = level;
            this.idUser = idUser;
            this.idCandidat = idCandidat;
            this.Questions = Questions;
        }

        public FindQuizzCandidateDto() { }
    }
}
