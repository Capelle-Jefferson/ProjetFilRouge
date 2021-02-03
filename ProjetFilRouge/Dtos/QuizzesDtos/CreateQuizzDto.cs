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
        public int? IdCandidat { get; set; }

        public CreateQuizzDto(DateTime date, int idCategory, int idLevel, int? idUser, int? idCandidat)
        {
            this.IdCategory = idCategory;
            this.IdLevel = idLevel;
            this.IdUser = idUser;
            this.IdCandidat = idCandidat;
        }

        public CreateQuizzDto() { }
    }
}
