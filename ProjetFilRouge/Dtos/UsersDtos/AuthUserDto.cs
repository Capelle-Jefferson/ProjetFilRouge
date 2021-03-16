using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.CandidatesDtos
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int IdRoles { get; set; }

        public CreateUserDto(string userName, string password, string firstname, string lastname, string email, int idRoles)
        {
            Username = userName;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            IdRoles = idRoles;
        }

        public CreateUserDto()
        {
        }
    }
}
