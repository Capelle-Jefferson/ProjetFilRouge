using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(QueryBuilder querryBuilder) : base(querryBuilder) { }

        public override User Create(User obj)
        {
            obj.IdUser = CreatedObject(obj, "user", "id_user");
            return obj;
        }

        public override int Delete(int id)
        {
            return DeletedObject("user", id, "id_user");
        }

        public override User Find(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("user")
                .Where("id_user", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            User user = new User();
            while (rdr.Read())
            {
                user.IdUser = rdr.GetInt32(0);
                user.Username = rdr.GetString(1);
                user.Password = rdr.GetString(2);
                user.Firstname = rdr.GetString(3);
                user.Lastname = rdr.GetString(4);
                user.Email = rdr.GetString(5);
                user.IdRoles = rdr.GetInt32(6);
            }
            this.CloseConnection(rdr);
            return user;
        }

        public override List<User> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("user")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<User> list = new List<User>();
            while (rdr.Read())
            {
                User user = new User
                {
                    IdUser = rdr.GetInt32(0),
                    Username = rdr.GetString(1),
                    Password = rdr.GetString(2),
                    Firstname = rdr.GetString(3),
                    Lastname = rdr.GetString(4),
                    Email = rdr.GetString(5),
                    IdRoles = rdr.GetInt32(6)
                };
                list.Add(user);
            }
            this.CloseConnection(rdr);
            return list;
        }

        public List<User> FindByIdRoles(int idRoles)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("user")
                .Where("id_roles", idRoles)
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<User> list = new List<User>();
            while (rdr.Read())
            {
                User user = new User
                {
                    IdUser = rdr.GetInt32(0),
                    Username = rdr.GetString(1),
                    Password = rdr.GetString(2),
                    Firstname = rdr.GetString(3),
                    Lastname = rdr.GetString(4),
                    Email = rdr.GetString(5),
                    IdRoles = rdr.GetInt32(6)
                };
                list.Add(user);
            }
            this.CloseConnection(rdr);
            return list;
        }

        public override User Update(int id, User obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> userDict = new Dictionary<string, dynamic>();
            userDict = ObjectToDictionary(obj, "id_user");
            string request = _queryBuilder
              .Update("user")
              .Set(userDict)
              .Where("id_user", id)
              .Get();
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            obj.IdUser = id;
            return obj;
        }
    }
}
