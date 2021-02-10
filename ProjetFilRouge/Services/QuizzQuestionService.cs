using ProjetFilRouge.Dtos.AnswerDtos;
using ProjetFilRouge.Dtos.QuizzQDTO;
using ProjetFilRouge.Models;
using ProjetFilRouge.Utils;
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
            List<FindQuizzQDto> listQuizzQDto = new List<FindQuizzQDto>();
            foreach (QuizzQuestion quizzQ in listQuizzQ)
            {
                FindQuizzQDto quizzQDto = TransformsModelToDTO(quizzQ);
                listQuizzQDto.Add(quizzQDto);
            }
            return listQuizzQDto;
        }

        internal List<FindQuizzQDto> GetQuizzQ(int idQuizz)
        {
            List<FindQuizzQDto> listQuizzQDto = new List<FindQuizzQDto>();
            List<QuizzQuestion> listquizzQ = quizzquestionsRepository.FindAll(idQuizz);
            
            if (listquizzQ[0].IdQuizz == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            foreach (QuizzQuestion quizzQ in listquizzQ)
            {
                FindQuizzQDto quizzQDto = TransformsModelToDTO(quizzQ);
                listQuizzQDto.Add(quizzQDto);
            }
            return listQuizzQDto;
        }

        public FindQuizzQDto AddAnswerCandidate(int idQuizz, int idQuestion, CreateAnswerDto answer)
        {
            AnswerServices answerServices = new AnswerServices();
            FindAnswerDto answerCreatedDto = answerServices.PostAnswer(answer);
            this.quizzquestionsRepository.AddAnswerCandidate(idQuizz, idQuestion, (int)answerCreatedDto.IdAnswer);
            return TransformsModelToDTO(quizzquestionsRepository.Find(idQuizz, idQuestion));
        }

        internal FindQuizzQDto PostQuizzQ(CreateQuizzQDto obj)
        {
            QuizzQuestion quizzQModel = transformsDtoToModel(obj);
            QuizzQuestion quizzQCreated = quizzquestionsRepository.Create(quizzQModel);
            return TransformsModelToDTO(quizzQCreated);
        }

        public int DeleteQuizzQ(int id)
        {
            return this.quizzquestionsRepository.Delete(id);
        }

        private QuizzQuestion transformsDtoToModel(CreateQuizzQDto obj)
        {
            return new QuizzQuestion((int)obj.IdQuizz, (int)obj.IdQuestion, obj.Comment, null, obj.IdAnswerCandidate);
        }

        private FindQuizzQDto TransformsModelToDTO(QuizzQuestion quizzQ)
        {
            return new FindQuizzQDto((int)quizzQ.IdQuizz, (int)quizzQ.IdQuestion, quizzQ.Comment, quizzQ.IsCorrectAnswer, quizzQ.IdAnswerCandidate);
        }
    }
}
