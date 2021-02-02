using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.RolesDtos
{
    public class CreatedRolesDto
    {
        public string nameRole { get; set; }

        public CreatedRolesDto( string nameRole)
        {
            this.nameRole = nameRole;
        }
    }
}
