using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class User
    {
        public int? IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int? IdRoles { get; set; }

        public User(int? id,string username,string password,string firstname,string lastname,string email,int? idRoles)
        {
            this.IdUser = id;
            this.Username = username;
            this.Password = password;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.IdRoles = idRoles;
        }

        public User()
        {
        }
    }
}
