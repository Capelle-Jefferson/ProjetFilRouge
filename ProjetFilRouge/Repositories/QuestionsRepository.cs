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

        /// <summary>
        /// Permet de créer une question grâce au QueryBuilder 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> la requête mysql pour insérer dans une table </returns>
        public override Question Create(Question obj)
        {
            obj.IdQuestion = CreatedObject(obj, "question", "id_question");
            return obj;
        }

        /// <summary>
        /// Permet de creer la requête sql pour supprimer une question selon son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> la requête mysql </returns>
        public override int Delete(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder.Delete("question", id);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            int result = cmd.ExecuteNonQuery();
            connectionSql.Close();
            return result;
        }

        /// <summary>
        /// Creer la requête sql "select" pour trouver la question
        /// </summary>
        /// <param name="id"></param>
        /// <returns>la requête sql</returns>
        public override Question Find(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("question")
                .Where("id_question", id, "=")
                .Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Question question = new Question();
            while (rdr.Read())
            {
                question.IdQuestion = rdr.GetInt32(0);
                question.Intitule = rdr.GetString(1);
                question.IdCategory = rdr.GetInt32(2);
                question.IdLevel = rdr.GetInt32(3);
                question.IdAnswer = rdr.GetInt32(4);
            }
            this.CloseConnection(rdr);
            return question;
        }

        public List<Question> Find(int id1, int id2)
        {
            this.OpenConnection();
            List<Question> list = new List<Question>();
            string request = _queryBuilder
                .Select()
                .From("question")
                .Where("id_level", id1, "=")
                .And("id_category", id2, "=")
                .Get();

            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Question question = new Question();
                question.IdQuestion = rdr.GetInt32(0);
                question.Intitule = rdr.GetString(1);
                question.IdCategory = rdr.GetInt32(2);
                question.IdLevel = rdr.GetInt32(3);
                question.IdAnswer = rdr.GetInt32(4);

                list.Add(question);
            }
            this.CloseConnection(rdr);
            return list;
        }

        /// <summary>
        /// Creer la requête sql pour selectionner toute la table
        /// </summary>
        /// <returns>la requête sql</returns>
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
                question.IdCategory = rdr.GetInt32(2);
                question.IdLevel = rdr.GetInt32(3);
                question.IdAnswer = rdr.GetInt32(4);


                list.Add(question);
            }

            this.CloseConnection(rdr);
            return list;
        }

        /// <summary>
        /// Creer la requête sql pour set une question (modifier/faire une mise à jour)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns>la requête sql</returns>
        public override Question Update(int id, Question obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> questionDict = new Dictionary<string, dynamic>();
            questionDict = ObjectToDictionary(obj, "id_question");
            string request = _queryBuilder
              .Update("question")
              .Set(questionDict)
              .Where("id_question", id)
              .Get();
            Console.WriteLine(request);
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            connectionSql.Close();
            obj.IdQuestion = id;
            return obj;
        }

        public List<Question> GenererQuestionQuizz(int idLevel, int idCategory, int nombreQuestion)
        {
            Random rnd = new Random();
            List<Question> listQuestion = Find(idLevel, idCategory);
            int taille = listQuestion.Count;
            List<Question> listQuestionQuizz = new List<Question>();
            if (taille < nombreQuestion)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < nombreQuestion; i++)
            {
                int qIndex = rnd.Next(0, taille);
                listQuestionQuizz.Add(listQuestion[qIndex]);
                listQuestion.RemoveAt(qIndex);
                taille--;
            }
            return listQuestionQuizz;
        }
    }
}