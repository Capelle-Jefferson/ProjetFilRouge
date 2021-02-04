using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.CandidatesDtos
{
    public class CreateUserDto
    {
        public int? IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdRoles { get; set; }

        public CreateUserDto(int? idUser, string userName, string password, string firstname, string lastname, string email, int idRoles)
        {
            IdUser = idUser;
            UserName = userName;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            IdRoles = idRoles;
        }

        public CreateUserDto()
        {
        }
    }
}
