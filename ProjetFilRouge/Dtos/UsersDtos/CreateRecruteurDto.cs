using ProjetFilRouge.Dtos.EmailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.CandidatesDtos
{
    public class CreateRecruteurDto
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public CreateRecruteurDto(string userName, string firstname, string lastname, string email)
        {
            Username = userName;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        public CreateRecruteurDto()
        {
        }
    }
}
