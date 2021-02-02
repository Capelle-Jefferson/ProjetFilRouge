using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.RolesDtos
{
    public class CreatedRolesDTO
    {
        public string nameRole { get; set; }

        public CreatedRolesDTO( string nameRole)
        {
            this.nameRole = nameRole;
        }
    }
}
