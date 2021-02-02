using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class RolesRepository : AbstractRepository<Roles>
    {
        public RolesRepository(QueryBuilder requestBuilder) : base(requestBuilder)
        {
        }

        public override Roles Create(Roles obj)
        {
            obj.idRoles = CreatedObject(obj, "roles", "id_roles");
            return obj;
        }

        public override int Delete(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("roles", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Roles Find(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("roles")
                .Where("id_roles", id, "=")
                .Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Roles role = new Roles();
            while (rdr.Read())
            {
                role.idRoles = rdr.GetInt32(0);
                role.nameRole = rdr.GetString(1);
              
            }
            rdr.Close();
            return role;
        }

        public override List<Roles> FindAll()
        {
            this.OpenConnection();

            List<Roles> list = new List<Roles>();

            string request = _queryBuilder   // Pour construire la requête sql
             .Select()
             .From("roles")
             .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Roles role = new Roles();
            while (rdr.Read())
            {
                role.idRoles = rdr.GetInt32(0);
                role.nameRole = rdr.GetString(1); 
                list.Add(role);
            }

            this.CloseConnection(rdr);
            return list;
        }

        public override Roles Update(int id, Roles obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> rolesDict = new Dictionary<string, dynamic>();
            rolesDict = ObjectToDictionary(obj, "id_roles");
            string request = _queryBuilder
              .Update("roles")
              .Set(rolesDict)
              .Where("id_roles", id)
              .Get();
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            obj.idRoles = id;
            return obj;
        }
    }
}
