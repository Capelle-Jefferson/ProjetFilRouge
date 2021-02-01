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
            this.OpenConnection();
            Dictionary<string, dynamic> questiondictionnary= ObjectToDictionary(obj, "id_question");

            string request = _queryBuilder
                .Insert("personnages")
                .Values(questiondictionnary);

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            int objId = Convert.ToInt32(cmd.LastInsertedId);
            obj.IdQuestion = objId;
            connectionSql.Close();
            return obj;
        }

        public override int Delete(long id)
        {
            throw new NotImplementedException();
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
