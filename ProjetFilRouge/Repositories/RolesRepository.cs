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
            throw new NotImplementedException();
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Roles Find(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
