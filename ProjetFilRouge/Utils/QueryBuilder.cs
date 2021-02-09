
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFilRouge.Utils
{
    public class QueryBuilder
    {
        public StringBuilder request = new StringBuilder();
        public QueryBuilder() { }

        internal QueryBuilder Select(params string[] values)
        {
            request.Clear();
            request.Append("SELECT ");
            if (values.Length > 0)
            {
                foreach (string value in values)
                {
                    request.Append($"{value},");
                }
                request.Remove((request.Length - 1), 1);
            }
            else
            {
                request.Append("*");
            }
            return this;
        }

        internal QueryBuilder Insert(string table)
        {
            request.Clear();
            request.Append($"INSERT INTO {table}");
            return this;
        }

        internal string Values(Dictionary<string, dynamic> obj)
        {
            request.Append("(");
            foreach (var key in obj.Keys)
            {
                request.Append($"{key},");
            }
            request.Remove((request.Length - 1), 1);
            request.Append(") VALUES (");
            foreach (var key in obj.Keys)
            {
                if (obj[key] is string)
                {
                    request.Append($"\"{obj[key]}\",");
                }
                else if (obj[key] is int || obj[key] is bool)
                {
                    request.Append($"{obj[key]},");
                }
                else if (obj[key] is double)
                {
                    string val = obj[key].ToString();
                    request.Append($"{val.Replace(',', '.')},");
                }
                else
                {
                    request.Append($"\"{obj[key]}\",");
                }
            }
            request.Remove((request.Length - 1), 1);
            request.Append(");");
            return request.ToString();
        }

        internal string Delete(string table, long id, string idName = "id")
        {
            request.Clear();
            return request.Append($"DELETE FROM {table} where {idName} = {id}").ToString();
        }

        internal string Get()
        {
            return request.ToString();
        }

        internal QueryBuilder Where(string key, dynamic value, string type = "=")
        {
            if(value is string)
            {
                request.Append($"WHERE {key} {type} '{value}'");
            }
            else
            {
                request.Append($"WHERE {key} {type} {value}");
            }
            return this;
        }

        internal QueryBuilder And(string key, dynamic value, string type = "=")
        {
            request.Append($" AND {key} {type} {value}");
            return this;
        }


        internal QueryBuilder From(string table)
        {
            request.Append($" FROM {table} ");
            return this;
        }

        internal QueryBuilder Update(string table)
        {
            request.Clear();
            request.Append($"UPDATE {table} ");
            return this;
        }

        internal QueryBuilder SetQuizzQuestion(int idAnswer)
        {
            request.Append($"SET id_candidat_answer = {idAnswer} ");
            return this;
        }

        internal QueryBuilder Set(Dictionary<string, dynamic> obj)
        {
            request.Append("SET ");
            foreach (var key in obj.Keys)
            {
                if (obj[key] is string)
                {
                    request.Append($"{key} = \"{obj[key]}\",");
                }
                else if (obj[key] is int || obj[key] is bool)
                {
                    request.Append($"{key} = {obj[key]},");
                }
                else if (obj[key] is double)
                {
                    string val = obj[key].ToString();
                    request.Append($"{key} = {val.Replace(',', '.')},");
                }
                else
                {
                    request.Append($"{key} = \"{obj[key]}\",");
                }

            }
            request.Remove((request.Length - 1), 1);
            request.Append(" ");
            return this;
        }
    }
}