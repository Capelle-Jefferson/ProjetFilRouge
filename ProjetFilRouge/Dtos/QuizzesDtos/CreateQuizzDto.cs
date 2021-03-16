using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class CreateQuizzDto
    {
        public int IdCategory { get; set; }
        public int IdLevel { get; set; }
        public int? IdUser { get; set; }
        public int? IdCandidate { get; set; }

        public CreateQuizzDto(DateTime date, int idCategory, int idLevel, int? idUser, int? idCandidate)
        {
            this.IdCategory = idCategory;
            this.IdLevel = idLevel;
            this.IdUser = idUser;
            this.IdCandidate = idCandidate;
        }

        public CreateQuizzDto() { }
    }
}
