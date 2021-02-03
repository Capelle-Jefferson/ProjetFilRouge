using ProjetFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.CandidatesDtos
{
    public class FindUserDto
    {
        public int? IdUser { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Fastname { get; set; }
        public string Email { get; set; }
        public int IdRoles { get; set; }

        public FindUserDto(int? idUser, string userName, string firstname, string fastname, string email, int idRoles)
        {
            IdUser = idUser;
            UserName = userName;
            Firstname = firstname;
            Fastname = fastname;
            Email = email;
            IdRoles = idRoles;
        }

        public FindUserDto()
        {
        }
    }
}
