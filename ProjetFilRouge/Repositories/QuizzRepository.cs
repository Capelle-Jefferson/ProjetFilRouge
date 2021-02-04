using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class QuizzRepository : AbstractRepository<Quizz>
    {
        public QuizzRepository(QueryBuilder query) : base(query) { }
        public override Quizz Create(Quizz obj)
        {
            obj.idQuizz = CreatedObject(obj, "quizz", "id_quizz");
            return obj;
        }

        /// <summary>
        ///     Suppression du quizz dans la bdd
        /// </summary>
        /// <param name="id">L'identifiant du quizz à supprimer</param>
        /// <returns>1 si le quizz à était supprimé, 0 sinon</returns>
        public override int Delete(int id)
        {
            return DeletedObject("quizz", id, "id_quizz");
        }

        /// <summary>
        ///     Récupération d'un quizz
        /// </summary>
        /// <param name="id">identifiant du quizz à récupérer</param>
        /// <returns>Quizz</returns>
        public override Quizz Find(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz")
                .Where("id_quizz", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Quizz quizz = new Quizz();
            while (rdr.Read())
            {
                quizz.idQuizz = rdr.GetInt32(0);
                quizz.codeQuizz = rdr.GetString(1);
                if(!rdr.IsDBNull(2))
                    quizz.date = rdr.GetDateTime(2);
                quizz.idCategory = rdr.GetInt32(3);
                quizz.idLevel = rdr.GetInt32(4);
                quizz.idUser = rdr.GetInt32(5);
                quizz.idCandidate = rdr.GetInt32(6);
            }
            this.CloseConnection(rdr);
            return quizz;
        }

        /// <summary>
        ///     Récupération de la liste des quizzes
        /// </summary>
        /// <returns>List<Quizz></returns>
        public override List<Quizz> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Quizz> list = new List<Quizz>();
            while (rdr.Read())
            {
                Quizz quizz = new Quizz();
                quizz.idQuizz = rdr.GetInt32(0);
                quizz.codeQuizz = rdr.GetString(1);
                if (!rdr.IsDBNull(2))
                    quizz.date = rdr.GetDateTime(2);
                quizz.idCategory = rdr.GetInt32(3);
                quizz.idLevel = rdr.GetInt32(4);
                quizz.idUser = rdr.GetInt32(5);
                quizz.idCandidate = rdr.GetInt32(6);
                list.Add(quizz);
            }
            this.CloseConnection(rdr);
            return list;
        }

        public override Quizz Update(int id, Quizz obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Récupèration un quizz
        /// </summary>
        /// <param name="code">Code du quizz à récupérer</param>
        /// <returns></returns>
        internal Quizz FindByCode(string code)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("quizz")
                .Where("code_quizz", code, "=")
                .Get();
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Quizz quizz = new Quizz();
            while (rdr.Read())
            {
                quizz.idQuizz = rdr.GetInt32(0);
                quizz.codeQuizz = rdr.GetString(1);
            }
            this.CloseConnection(rdr);
            return quizz;
        }
    }
}
