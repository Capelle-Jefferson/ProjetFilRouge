using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Roles
    {
        public int? idRoles { get; set; }
        public string nameRole { get; set; }

        public Roles(int? idRoles, string nameRole)
        {
            this.idRoles = idRoles;
            this.nameRole = nameRole;
        }
    }
}
