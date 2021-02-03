using ProjetFilRouge.Dtos.QuizzQDTO;
using ProjetFilRouge.Utils;
using ProjetTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetFilRouge.Services
{
    public class QuizzQuestionService
    {
        Repositories.QuizzQuestionRepository quizzquestionsRepository;
        public QuizzQuestionService()
        {
            this.quizzquestionsRepository = new Repositories.QuizzQuestionRepository(new QueryBuilder());
        }

        internal List<FindQuizzQDto> GettAllQuizzQ()
        {
            List<QuizzQuestion> listQuizzQ = quizzquestionsRepository.FindAll();
            List<FindQuizzQDto> listQuestionDto = new List<FindQuizzQDto>();
            foreach (QuizzQuestion quizzQ in listQuizzQ)
            {
                FindQuizzQDto quizzQDto = TransformsModelToDTO(quizzQ);
                listQuestionDto.Add(quizzQDto);
            }
            return listQuestionDto;
        }

        private FindQuizzQDto TransformsModelToDTO(QuizzQuestion quizzQ)
        {
            return new FindQuizzQDto((int)quizzQ.IdQuizz, (int)quizzQ.IdQuestion, quizzQ.Comment, quizzQ.IdAnswerCandidate);
        }

        internal FindQuizzQDto GetQuizzQ(int idQuizz)
        {
            QuizzQuestion quizzQ = quizzquestionsRepository.Find(idQuizz);
            if (quizzQ.IdQuizz == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            FindQuizzQDto quizzQDto = TransformsModelToDTO(quizzQ);
            return quizzQDto;
        }

        internal FindQuizzQDto PostQuizzQ(CreateQuizzQDto obj)
        {
            QuizzQuestion quizzQModel = transformsDtoToModel(obj);
            QuizzQuestion quizzQCreated = quizzquestionsRepository.Create(quizzQModel);
            return TransformsModelToDTO(quizzQCreated);
        }

        private QuizzQuestion transformsDtoToModel(CreateQuizzQDto obj)
        {
            return new QuizzQuestion((int)obj.IdQuizz, (int)obj.IdQuestion, obj.Comment, obj.IdAnswerCandidate);
        }
    }
}
