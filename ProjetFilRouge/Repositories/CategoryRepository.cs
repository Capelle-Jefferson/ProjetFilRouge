using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class CategoryRepository : AbstractRepository<Category>
    {
        public CategoryRepository(QueryBuilder queryBuilder) : base(queryBuilder) { }

        public override Category Create(Category obj)
        {
            throw new NotImplementedException();
        }

        public override int Delete(long id)
        {
            throw new NotImplementedException();
        }

        public override Category Find(long id)
        {
            this.openConnection();
            string request = _queryBuilder
                .Select()
                .From("category")
                .Where("id_category", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Category cat = new Category();
            while (rdr.Read())
            {
                cat.idCategory = rdr.GetInt32(0);
                cat.nameCategory = rdr.GetString(1);
            }
            this.closeConnection(rdr);
            return cat;
        }

        public override List<Category> FindAll()
        {
            this.openConnection();
            string request = _queryBuilder
                .Select()
                .From("category")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Category> list = new List<Category>();
            while (rdr.Read())
            {
                Category cat = new Category();
                cat.idCategory = rdr.GetInt32(0);
                cat.nameCategory = rdr.GetString(1);
                list.Add(cat);
            }
            this.closeConnection(rdr);
            return list;
        }

        public override Category Update(long id, Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
