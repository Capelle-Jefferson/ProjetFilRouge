using MySql.Data.MySqlClient;
using ProjetFilRouge.Utils;
using ProjetFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class AnswerRepository : AbstractRepository<Answer>
    {
        public AnswerRepository(QueryBuilder queryBuilder) : base(queryBuilder) { }

        public override Answer Create(Answer obj)
        {
            obj.TypeAnswer = ConvertTypeAnswer(obj.TypeAnswer.ToString());
            obj.IdAnswer = CreatedObject(obj, "answer", "id_answer");
            return obj;
        }

        public override int Delete(int id)
        {
            return DeletedObject("answer", id, "id_answer");
        }

        public override Answer Find(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("answer")
                .Where("id_answer", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Answer ans = new Answer();
            while (rdr.Read())
            {
                ans.IdAnswer = rdr.GetInt32(0);
                ans.TypeAnswer = ConvertTypeAnswer(rdr.GetString(1));
                ans.Explication = rdr.GetString(2);
                ans.TextAnswer = rdr.GetString(3);
            }
            this.CloseConnection(rdr);
            return ans;
        }

        private TypeAnswer ConvertTypeAnswer(string v)
        {
            switch (v)
            {
                case "QCM":
                    return TypeAnswer.QCM;
                case "QCM_Multiple":
                    return TypeAnswer.QCM_multiple;
                case "Text":
                    return TypeAnswer.Text;
                default:
                    return TypeAnswer.Text;
            }
        }

        public override List<Answer> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("answer")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Answer> list = new List<Answer>();
            while (rdr.Read())
            {
                Answer ans = new Answer();
                ans.IdAnswer = rdr.GetInt32(0);
                ans.TypeAnswer = ConvertTypeAnswer(rdr.GetString(1));
                ans.Explication = rdr.GetString(2);
                if (rdr.IsDBNull(3))
                {
                    ans.TextAnswer = null;
                }else
                {
                    ans.TextAnswer = rdr.GetString(3);
                }
                
                list.Add(ans);
            }    
            this.CloseConnection(rdr);
            return list;
        }

        public override Answer Update(int id, Answer obj)
        {
            obj.TypeAnswer = ConvertTypeAnswer(obj.TypeAnswer.ToString());
            UpdatedObject(obj, id, "answer", "id_answer");
            return Find(id);
        }
    }
}
