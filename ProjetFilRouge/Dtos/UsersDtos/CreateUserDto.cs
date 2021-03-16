using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.CandidatesDtos
{
    public class AuthUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthUserDto(string userName, string password)
        {
            Username = userName;
            Password = password;
        }

        public AuthUserDto()
        {
        }
    }
}
