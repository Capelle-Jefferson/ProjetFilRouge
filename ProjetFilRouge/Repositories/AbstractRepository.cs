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
        public abstract T Find(int id);
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
        public abstract T Update(int id, T obj);
        /**
        * Permet de supprimer un objet
        */
        public abstract int Delete(int id);

        public void openConnection()
        {
            Console.WriteLine("Connecting to MySQL...");
            connectionSql.Open();
        }

        public void closeConnection(MySqlDataReader reader)
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
                    string snakeName = ConvertCamelCaseToSnakecase(pr.Name);
                    dict.Add(snakeName.ToLower(), pr.GetValue(obj));
                }
            }
            return dict;
        }

        public int CreatedObject(T obj, string table, string idName = "id")
        {
            this.openConnection();
            Dictionary<string, dynamic> dict = this.ObjectToDictionary(obj, idName);
            string request = _queryBuilder
                .Insert(table)
                .Values(dict);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            int key = Convert.ToInt32(cmd.LastInsertedId);
            connectionSql.Close();
            return key;
        }

        private string ConvertCamelCaseToSnakecase(string name)
        {
            int n = name.Length;
            StringBuilder snakeName = new StringBuilder();
            snakeName.Append(name[0]);
            for (int i = 1; i < n; i++)
            {
                if (Char.IsUpper(name[i]))
                {
                    snakeName.Append("_");
                }
                snakeName.Append(name[i]);
            }
            return snakeName.ToString();
        }

        protected int DeletedObject(string table, int id, string idName)
        {
            this.openConnection();
            string request = _queryBuilder.Delete(table, id, idName);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        protected void UpdatedObject(T obj, int id, string table, string idName)
        {
            this.openConnection();
            Dictionary<string, dynamic> persoDictionnary = this.ObjectToDictionary(obj, idName);
            string request = _queryBuilder
              .Update(table)
              .Set(persoDictionnary)
              .Where(idName, id).Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
        }
    }
}
