using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Quizz
    {
        public int? idQuizz { get; set; }
        public string codeQuizz { get; set; }
        public DateTime date { get; set; }
        public int? idCategory { get; set; }
        public int? idLevel { get; set; }
        public int? idUser { get; set; }
        public int? idCandidat { get; set; }

        public Quizz(int? idQuizz, string codeQuizz, DateTime date, int? idCategory, int? idLevel, int? idUser, int? idCandidat)
        {
            this.idQuizz = idQuizz;
            this.codeQuizz = codeQuizz;
            this.date = date;
            this.idCategory = idCategory;
            this.idLevel = idLevel;
            this.idUser = idUser;
            this.idCandidat = idCandidat;
        }
    }
}
