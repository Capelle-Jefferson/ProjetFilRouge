using ProjetFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.CandidatesDtos
{
    public class FindCandidateDto
    {
        public int? idCandidat { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string Level { get; set; }
        public int idUser { get; set; }

        public FindCandidateDto(int? idCandidat, string firstname, string lastname, string email, string level, int idUser)
        {
            this.idCandidat = idCandidat;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.Level = level;
            this.idUser = idUser;
        }

        public FindCandidateDto()
        {
        }
    }
}
