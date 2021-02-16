using ProjetFilRouge.Dtos.CandidatesDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Services
{
    public class UsersServices
    {
        private UserRepository UserRepository;

        public UsersServices()
        {
            UserRepository = new UserRepository(new QueryBuilder());
        }

        public List<FindUserDto> GetUsers()
        {
            List<User> users = UserRepository.FindAll();
            List<FindUserDto> UserDtos = new List<FindUserDto>();
            foreach (User u in users)
            {
                UserDtos.Add(TransformModelToDto(u));
            }
            return UserDtos;
        }

        public FindUserDto GetUserById(int id)
        {
            User user = this.UserRepository.Find(id);
            return TransformModelToDto(user);
        }

        public List<FindUserDto> GetUserByIdRoles(int id)
        {
            List<User> user = UserRepository.FindByIdRoles(id);
            List<FindUserDto> UserDtos = new List<FindUserDto>();
            foreach (User u in user)
            {
                UserDtos.Add(TransformModelToDto(u));
            }
            return UserDtos;
        }

        public FindUserDto PostUser(CreateUserDto user)
        {
            User userModel = TransformDtoToModel(user);
            User candidatCreated = UserRepository.Create(userModel);
            return TransformModelToDto(candidatCreated);
        }

        /// <summary>
        /// Permet de modifier une donnée dans la table roles de la bdd
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns>le dto de la donnée modifiée </returns>
        internal FindUserDto PutUser(int id, CreateUserDto user)
        {
            User userModels = TransformDtoToModel(user);
            User userUpdate = UserRepository.Update(id, userModels);
            return TransformModelToDto(userUpdate);
        }
        
        internal int DeleteUser(int id)
        {
            return UserRepository.Delete(id);
        }

        private User TransformDtoToModel(CreateUserDto user)
        {
            return new User(
                null,
                user.Username,
                user.Password,
                user.Firstname,
                user.Lastname,
                user.Email,
                user.IdRoles
                );
        }

        private FindUserDto TransformModelToDto(User user)
        {
            int idr = 0;
            string r = "";
            RolesRepository repo = new RolesRepository(new QueryBuilder());
            if (user.IdRoles != null)
            {
                idr = (int)repo.Find((int)user.IdRoles).idRoles;
                r = ConvertIdRoleToRole(idr);
            }
            return new FindUserDto(
                    user.IdUser,
                    user.Username,
                    user.Firstname,
                    user.Lastname,
                    user.Email,
                    idr,
                    r);
        }

        private string ConvertIdRoleToRole(int idr)
        {
            RolesRepository repo = new RolesRepository(new QueryBuilder());            
            Roles role = repo.Find(idr);
            return role.nameRole.ToUpper();
        }
    }
}
