using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class ChoiceAnswerRepository : AbstractRepository<ChoiceAnswer>
    {
        public ChoiceAnswerRepository(QueryBuilder requestBuilder) : base(requestBuilder)
        {
        }

        public override ChoiceAnswer Create(ChoiceAnswer obj)
        {
            obj.IdChoiceAnswer = CreatedObject(obj, "choice_answer", "id_choice_answer");
            return obj;
        }

        public override int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  List<ChoiceAnswer> FindList (int id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("choice_answer")
                .Where("id_answer", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            List<ChoiceAnswer> listChoices = new List<ChoiceAnswer>();
            while (rdr.Read())
            {
                ChoiceAnswer choice = new ChoiceAnswer();
                choice.IdChoiceAnswer = rdr.GetInt32(0);
                if(!rdr.IsDBNull(1))
                    choice.TextAnswer = rdr.GetString(1);
                choice.IsAnswer = rdr.GetBoolean(2);
                choice.IdAnswer = rdr.GetInt32(3);
                listChoices.Add(choice);
            }
            this.CloseConnection(rdr);
            return listChoices;
        }

        public override ChoiceAnswer Find(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ChoiceAnswer> FindAll()
        {
            throw new NotImplementedException();
        }

        public override ChoiceAnswer Update(int id, ChoiceAnswer obj)
        {
            throw new NotImplementedException();
        }
    }
}
