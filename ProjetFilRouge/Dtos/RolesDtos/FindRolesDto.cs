using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.RolesDtos
{
    public class FindRolesDto
    {
        public int? idRoles { get; set; }
        public string nameRole { get; set; }

        public FindRolesDto(int? idRoles, string nameRole)
        {
            this.idRoles = idRoles;
            this.nameRole = nameRole;
        }
    }
}
