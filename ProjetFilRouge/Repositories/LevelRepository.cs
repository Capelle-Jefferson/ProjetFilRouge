using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class LevelRepository : AbstractRepository<Level>
    {
        public LevelRepository(QueryBuilder queryBuilder) : base(queryBuilder) { }

        public override Level Create(Level obj)
        {
            obj.IdLevel = CreatedObject(obj, "level", "id_level");
            return obj;
        }

        public override int Delete(int id)
        {
            return DeletedObject("level", id, "id_level");
        }

        public override Level Find(int id)
        {
            this.openConnection();
            string request = _queryBuilder
                .Select()
                .From("level")
                .Where("id_level", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Level lev = new Level();
            while (rdr.Read())
            {
                lev.IdLevel = rdr.GetInt32(0);
                lev.NameLevel = rdr.GetString(1);
            }
            this.closeConnection(rdr);
            return lev;
        }

        public override List<Level> FindAll()
        {
            this.openConnection();
            string request = _queryBuilder
                .Select()
                .From("level")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Level> list = new List<Level>();
            while (rdr.Read())
            {
                Level lev = new Level
                {
                    IdLevel = rdr.GetInt32(0),
                    NameLevel = rdr.GetString(1)
                };
                list.Add(lev);
            }
            this.closeConnection(rdr);
            return list;
        }

        public override Level Update(int id, Level obj)
        {
            UpdatedObject(obj, id, "level", "id_level");
            return Find(id);
        }
    }
}
