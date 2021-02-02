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
        internal List<FindRolesDto> GetAllRoles()
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
        /// Permet de persister la bdd dans la table roles
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>un dto pour l'utilisateur afin de visualiser ce qu'il a inséré</returns>
        internal FindRolesDto PostRole(CreatedRolesDto obj)
        {
            Roles roleModel = TransformsDtoToModel(obj);
            Roles roleCreated = rolesRepository.Create(roleModel);
            return TransformsModelToDTO(roleCreated);
        }

        /// <summary>
        /// Permet de supprimer une donnée de la table roles dans la bdd.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> 1 si tout c'est bien passé, 0 sinon </returns>
        internal int DeleteRole(int id)
        {
            return rolesRepository.Delete(id);
        }

        /// <summary>
        /// Permet de modifier une donnée dans la table roles de la bdd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns>le dto de la donnée modifiée </returns>
        internal FindRolesDto PutRole(int id, CreatedRolesDto obj)
        {
            Roles rolesModels = TransformsDtoToModel(obj);
            Roles roleUpdate = rolesRepository.Update(id, rolesModels);
            return TransformsModelToDTO(roleUpdate);
        }

        /// <summary>
        /// Recuperer un role selon son id dans la bdd
        /// </summary>
        /// <param name="id"></param>
        /// <returns>un role</returns>
        internal FindRolesDto GetRoles(int id)
        {
            Roles role = rolesRepository.Find(id);
            if (role.idRoles == null)
            {
                throw new KeyNotFoundException();
            }
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
            return new FindRolesDto(role.idRoles, role.nameRole);
        }
        /// <summary>
        /// Convertit un roleDTO en role Model pour persister dans la bdd
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>un role DTO pour l'utilisateur</returns>
        private Roles TransformsDtoToModel(CreatedRolesDto obj)
        {
            return new Roles(null, obj.nameRole);
        }
    }
}
