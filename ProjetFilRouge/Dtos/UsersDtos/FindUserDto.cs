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
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int IdRoles { get; set; }
        public string Role { get; set; }

        public FindUserDto(int? idUser, string username, string firstname, string lastname, string email, int idRoles, string role)
        {
            IdUser = idUser;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            IdRoles = idRoles;
            Role = role;
        }

        public FindUserDto()
        {
        }
    }
}
