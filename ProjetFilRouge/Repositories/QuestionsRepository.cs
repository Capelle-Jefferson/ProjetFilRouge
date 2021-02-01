using MySql.Data.MySqlClient;
using ProjetFilRouge.Utils;
using ProjetTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class QuestionsRepository : AbstractRepository<Question>
    {
        

        public QuestionsRepository(QueryBuilder _queryBuilder) : base(_queryBuilder) { }
        public override Question Create(Question obj)
        {
            obj.IdQuestion = CreatedObject(obj, "question", "id_question");
            return obj;
        }

        public override int Delete(long id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("question", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        public override Question Find(long id)
        {
            throw new NotImplementedException();
        }

        public override List<Question> FindAll()
        {
            this.OpenConnection();

            List<Question> list = new List<Question>();

            string request = _queryBuilder   // Pour construire la requête sql
             .Select()
             .From("personnages")
             .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Question question = new Question();
            while (rdr.Read())
            {
                question.IdQuestion = rdr.GetInt32(0);
                question.Intitule = rdr.GetString(1);
                question.IdCategory= rdr.GetInt32(2);
                question.IdLevel = rdr.GetInt32(0);
                question.IdAnswer = rdr.GetInt32(0);


                list.Add(question);
            }

            this.CloseConnection(rdr);
            return list;
        }

        public override Question Update(long id, Question obj)
        {
            throw new NotImplementedException();
        }
    }
}
