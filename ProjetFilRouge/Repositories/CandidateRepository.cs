using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetFilRouge.Repositories
{

    public class CandidateRepository : AbstractRepository<Candidate>
    {
        public CandidateRepository(QueryBuilder queryBuilder) : base(queryBuilder) { }

        public override Candidate Create(Candidate obj)
        {
            obj.idCandidate = CreatedObject(obj, "candidate", "id_candidate");
            return obj;
        }

        public override int Delete(int id)
        {
            return DeletedObject("candidate", id, "id_candidate");
        }

        public override Candidate Find(int id)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("candidate")
                .Where("id_candidate", id, "=")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Candidate cand = new Candidate();
            while (rdr.Read())
            {
                cand.idCandidate = rdr.GetInt32(0);
                cand.firstname = rdr.GetString(1);
                cand.lastname = rdr.GetString(2);
                cand.email = rdr.GetString(3);
                cand.idUser = rdr.GetInt32(4);
                cand.idLevel = rdr.GetInt32(5);
            }
            this.CloseConnection(rdr);
            return cand;
        }

        public override List<Candidate> FindAll()
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("candidate")
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Candidate> list = new List<Candidate>();
            while (rdr.Read())
            {
                Candidate cand = new Candidate();
                cand.idCandidate = rdr.GetInt32(0);
                cand.firstname = rdr.GetString(1);
                cand.lastname = rdr.GetString(2);
                cand.email = rdr.GetString(3);
                cand.idUser = rdr.GetInt32(4);
                cand.idLevel = rdr.GetInt32(5);
                list.Add(cand);
            }
            this.CloseConnection(rdr);
            return list;
        }

        public List<Candidate> FindByIdUser(int idUser)
        {
            this.OpenConnection();
            string request = _queryBuilder
                .Select()
                .From("candidate")
                .Where("id_user", idUser)
                .Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Candidate> list = new List<Candidate>();
            while (rdr.Read())
            {
                Candidate cand = new Candidate();
                cand.idCandidate = rdr.GetInt32(0);
                cand.firstname = rdr.GetString(1);
                cand.lastname = rdr.GetString(2);
                cand.email = rdr.GetString(3);
                cand.idUser = rdr.GetInt32(4);
                cand.idLevel = rdr.GetInt32(5);
                list.Add(cand);
            }
            this.CloseConnection(rdr);
            return list;
        }

        public override Candidate Update(int id, Candidate obj)
        {
            this.OpenConnection();
            Dictionary<string, dynamic> candidateDictionnary = this.ObjectToDictionary(obj, "id_candidate");
            string request = _queryBuilder
              .Update("candidate")
              .Set(candidateDictionnary)
              .Where("id_candidate", id).Get();
            MySqlCommand cmd = new MySqlCommand(request, connectionSql);
            cmd.ExecuteNonQuery();
            obj.idCandidate = Convert.ToInt32(cmd.LastInsertedId);
            connectionSql.Close();
            return obj;
        }
    }
}
