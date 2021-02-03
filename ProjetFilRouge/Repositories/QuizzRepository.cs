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

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

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
                quizz.date = rdr.GetDateTime(2);
                quizz.idCategory = rdr.GetInt32(3);
                quizz.idLevel = rdr.GetInt32(4);
                quizz.idUser = rdr.GetInt32(5);
                quizz.idCandidate = rdr.GetInt32(6);
            }
            this.CloseConnection(rdr);
            return quizz;
        }

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
                quizz.date = rdr.GetDateTime(2);
                quizz.idCategory = rdr.GetInt32(3);
                quizz.idLevel = rdr.GetInt32(4);
                quizz.idUser = rdr.GetInt32(5);
                quizz.idCandidate = rdr.GetInt32(6);
            }
            this.CloseConnection(rdr);
            return quizz;
        }
    }
}
