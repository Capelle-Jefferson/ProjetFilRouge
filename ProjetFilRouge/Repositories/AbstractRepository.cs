using MySql.Data.MySqlClient;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjetFilRouge.Repositories
{
    public abstract class AbstractRepository<T>    
    {
        public MySqlConnection connectionSql = ConnectionSql.getConnection();

        protected QueryBuilder _queryBuilder;
        public AbstractRepository(QueryBuilder requestBuilder)
        {
            this._queryBuilder = requestBuilder;
        }

        /**
         * Permet de récupérer un objet
         */
        /// <param name="id"> id de référence en bdd</param>
        /// <returns>Renvoi un objet</returns>
        public abstract T Find(long id);
        
        /**
         * Permet de récupérer une liste d'objet
         */
        /// <returns>Renvoi une liste d'objet</returns>
        public abstract List<T> FindAll();
        /**
        * Permet de persister un objet
        */
        public abstract T Create(T obj);
        /**
        * Permet de modifier un objet
        */
        public abstract T Update(long id, T obj);
        /**
        * Permet de supprimer un objet
        */
        public abstract int Delete(long id);

        public void OpenConnection ()
        {
            Console.WriteLine("Connecting to MySQL...");
            connectionSql.Open();       
        }
        
        public void CloseConnection (MySqlDataReader reader)
        {
            Console.WriteLine("Close MySQL...");
            reader.Close();
            connectionSql.Close();       
        }
        public Dictionary<string, dynamic> ObjectToDictionary(T obj, string idName)
        {
            Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();
            foreach (PropertyInfo pr in obj.GetType().GetProperties())
            {
                if (pr.Name.ToLower() != idName && pr.GetValue(obj) != null)
                {
                    dict.Add(pr.Name.ToLower(), pr.GetValue(obj));
                }
            }
            return dict;
        }
    }
}
