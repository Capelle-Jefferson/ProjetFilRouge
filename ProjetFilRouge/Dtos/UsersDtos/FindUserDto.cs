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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdRoles { get; set; }
        public string Role { get; set; }

        public FindUserDto(int? idUser, string username, string firstname, string lastname, string email, int idRoles, string role)
        {
            IdUser = idUser;
            UserName = username;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            IdRoles = idRoles;
            Role = role;
        }

        public FindUserDto()
        {
        }
    }
}
