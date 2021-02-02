using ProjetFilRouge.Dtos.RolesDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Services
{
    public class RolesServices
    {
        Repositories.RolesRepository rolesRepository;


        public RolesServices()
        {
            this.rolesRepository = new Repositories.RolesRepository(new QueryBuilder());
        }

        /// <summary>
        /// Recuperer toutes les données de la table roles 
        /// </summary>
        /// <returns>Liste de DTO </returns>
        internal List<FindRolesDto> GetAllRoles(int id)
        {
            List<Roles> listRoles = rolesRepository.FindAll();
            List<FindRolesDto> listRolesDto = new List<FindRolesDto>();
            foreach (Roles role in listRoles)
            {
                FindRolesDto rolesDto = TransformsModelToDTO(role);
                listRolesDto.Add(rolesDto);
            }
            return listRolesDto;
        }
        /// <summary>
        /// Recuperer un role selon son id dans la bdd
        /// </summary>
        /// <param name="id"></param>
        /// <returns>un role</returns>
        internal FindRolesDto GetRoles(int id)
        {
            Roles role = rolesRepository.Find(id);
            FindRolesDto roleDto = TransformsModelToDTO(role);
            return roleDto;
        }

        /// <summary>
        /// Permet de convertir un roleModel en roleDTO
        /// </summary>
        /// <param name="role"></param>
        /// <returns>Un roleDTO</returns>
        private FindRolesDto TransformsModelToDTO(Roles role)
        {
            return new FindRolesDto(role.idRoles,role.nameRole);
        }
    }
}
