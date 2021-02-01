using ProjetFilRouge.Utils;
using ProjetTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Repositories
{
    public class QuestionsRepository : AbstractRepository<Question>
    {
        public QuestionsRepository(QueryBuilder queryBuilder) : base(queryBuilder) { }
        public override Question Create(Question obj)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override Question Update(long id, Question obj)
        {
            throw new NotImplementedException();
        }
    }
}
