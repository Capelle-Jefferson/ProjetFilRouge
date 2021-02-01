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

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Category Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Category> FindAll()
        {
            this.OpenConnection();
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
            this.CloseConnection(rdr);
            return list;
        }

        public override Category Update(int id, Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
