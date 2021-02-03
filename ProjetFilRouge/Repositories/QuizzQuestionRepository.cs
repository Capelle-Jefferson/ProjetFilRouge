using MySql.Data.MySqlClient;
using ProjetFilRouge.Utils;
using ProjetTest.Models;
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
            throw new NotImplementedException();
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
