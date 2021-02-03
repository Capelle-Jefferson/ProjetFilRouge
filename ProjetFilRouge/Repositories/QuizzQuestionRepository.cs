using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class QuizzQuestionRepository : AbstractRepository<QuizzQuestion>
    {
        public QuizzQuestionRepository(QueryBuilder requestBuilder) : base(requestBuilder)
        {
        }

        public override QuizzQuestion Create(QuizzQuestion obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> dict = this.ObjectToDictionary(obj,"id");
            string request = _queryBuilder
                .Insert("quizz_question")
                .Values(dict);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            return obj;
        }

        public override QuizzQuestion Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<QuizzQuestion> FindAll()
        {
            this.OpenConnection();

            List<QuizzQuestion> listQuizzQ = new List<QuizzQuestion>();

            string request = _queryBuilder   // Pour construire la requête sql
             .Select()
             .From("quizz_question")
             .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                QuizzQuestion quizzQ = new QuizzQuestion();
                quizzQ.IdQuizz = rdr.GetInt32(0);
                quizzQ.IdQuestion = rdr.GetInt32(1);
                quizzQ.Comment = rdr.GetString(2);
                if (rdr.IsDBNull(3))
                {
                    quizzQ.IdAnswerCandidate = null;
                }
                else
                {
                    quizzQ.IdAnswerCandidate = rdr.GetInt32(3);
                }
                
                listQuizzQ.Add(quizzQ);
            }

            this.CloseConnection(rdr);
            return listQuizzQ;
        }

        public List<QuizzQuestion> FindAll(int id)
        {
            this.OpenConnection();

            List<QuizzQuestion> listQuizzQ = new List<QuizzQuestion>();

            string request = _queryBuilder 
             .Select()
             .From("quizz_question")
             .Where("id_quizz", id,"=")
             .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                QuizzQuestion quizzQ = new QuizzQuestion();
                quizzQ.IdQuizz = rdr.GetInt32(0);
                quizzQ.IdQuestion = rdr.GetInt32(1);
                quizzQ.Comment = rdr.GetString(2);
                if (rdr.IsDBNull(3))
                {
                    quizzQ.IdAnswerCandidate = null;
                }
                else
                {
                    quizzQ.IdAnswerCandidate = rdr.GetInt32(3);
                }

                listQuizzQ.Add(quizzQ);
            }

            this.CloseConnection(rdr);
            return listQuizzQ;
        }

        public override QuizzQuestion Update(int id, QuizzQuestion obj)
        {
            throw new NotImplementedException();
        }
        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
