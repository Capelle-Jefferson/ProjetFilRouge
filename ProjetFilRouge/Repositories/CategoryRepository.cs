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

        /// <summary>
        /// Creation d'une catégorie  
        /// </summary>
        /// <param name="obj">objet Category à créer</param>
        /// <returns>Objet category créé</returns>
        public override Category Create(Category obj)
        {
            obj.IdCategory = CreatedObject(obj, "category", "id_category");
            return obj;
        }

        /// <summary>
        /// Supprime la catégorie dont l'identifiant est id 
        /// </summary>
        /// <param name="id">identifiant de la catégorie à supprimer</param>
        /// <returns>1 si la catégorie a bien été supprimé, 0 sinon</returns>
        public override int Delete(int id)
        {
            return DeletedObject("category", id, "id_category");
        }

        /// <summary>
        /// Selectionne une catégorie dont l'identifiant est id 
        /// </summary>
        /// <param name="id">identifiant de la catégorie à selectionner</param>
        /// <returns>objet Catégorie</returns>
        public override Category Find(int id)
        {
            this.OpenConnection();
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
                cat.IdCategory = rdr.GetInt32(0);
                cat.NameCategory = rdr.GetString(1);
            }
            this.CloseConnection(rdr);
            return cat;
        }

        /// <summary>
        /// Selectionne toutes les catégories
        /// </summary>
        /// <returns>Liste de Catégories</returns>
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
                cat.IdCategory = rdr.GetInt32(0);
                cat.NameCategory = rdr.GetString(1);
                list.Add(cat);
            }
            this.CloseConnection(rdr);
            return list;
        }

        /// <summary>
        /// Met à jour la catégorie dont l'identifiant est id 
        /// </summary>
        /// <param name="id">l'indentifiant de la catégorie à modifier</param>
        /// <param name="obj">La nouvelle Catégorie</param>
        /// <returns>La nouvelle Catégorie</returns>
        public override Category Update(int id, Category obj)
        {
            UpdatedObject(obj, id, "category", "id_category");
            return Find(id);
        }
    }
}
