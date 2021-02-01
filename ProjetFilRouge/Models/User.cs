using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class User
    {
        public int? idUser { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int? idRoles { get; set; }

        public User(int? id,string username,string password,string firstname,string lastname,string email,int? idRoles)
        {
            this.idUser = id;
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.idRoles = idRoles;

        }

    }
}
