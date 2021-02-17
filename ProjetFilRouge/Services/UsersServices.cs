using ProjetFilRouge.Dtos.CandidatesDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

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

        internal FindUserDto IsAvailableUser(string username, string password)
        {
            User user = this.UserRepository.FindByUsername(username);
            if(user == null)
                return null;
            else if (!VerifyHash(password, user.Password))
                return null;
            else
                return TransformModelToDto(user);
        }

        public FindUserDto PostUser(CreateUserDto user)
        {
            user.Password = EncodingPassword(user);
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

        /// <summary>
        ///     Crypte le mot de passe pour l'enregistrer dans la base de données
        /// </summary>
        /// <param name="user">Objet User contenant le mot de passe</param>
        /// <returns>le mot de passe crypté</returns>
        private string EncodingPassword(CreateUserDto user)
        {
            string passwordHash = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                passwordHash = GetHash(sha256Hash, user.Password);
            }
            return passwordHash;
        }

        /// <summary>
        ///     Crypte input
        /// </summary>
        /// <param name="hashAlgorithm">HashAlgorithm</param>
        /// <param name="input">mot à crypter</param>
        /// <returns>input crypté</returns>
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        ///     Verifie si stringNonCrypter est égal à hash
        /// </summary>
        /// <param name="hashAlgorithm">HashAlgorithm</param>
        /// <param name="stringNonCrypter">Mot non hasher à vérifier</param>
        /// <param name="hash">Mot hasher</param>
        /// <returns></returns>
        private static bool VerifyHash(string stringNonCrypter, string hash)
        {
            StringComparer comparer;
            string hashOfInput;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hashOfInput = GetHash(sha256Hash, stringNonCrypter);
                comparer = StringComparer.OrdinalIgnoreCase;
            }
            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
