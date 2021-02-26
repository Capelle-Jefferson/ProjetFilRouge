using ProjetFilRouge.Dtos.AnswerDtos;
using ProjetFilRouge.Dtos.QuestionsDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetFilRouge.Services
{
    public class QuestionsServices
    {
        QuestionsRepository questionsRepository;
        AnswerServices AnswerServices;
        public QuestionsServices (QuestionsRepository questionsRepository, AnswerServices answerServices)
            {
            this.questionsRepository = questionsRepository;
            AnswerServices = answerServices;
            }
        /// <summary>
        /// Récupère toute les questions présentes dans la base de données
        /// </summary>
        /// <returns>List de questions</returns>
        internal List<FindQuestionsDto> GetAllQuestions()
        {
            List<Question> listQuestions = questionsRepository.FindAll();
            List<FindQuestionsDto> listQuestionDto =new List<FindQuestionsDto>();
            foreach (Question question in listQuestions)
            {
                FindQuestionsDto questionDto = TransformsModelToDTO(question);
                listQuestionDto.Add(questionDto);
            }
            return listQuestionDto;
        }

        /// <summary>
        /// Récupère une question précise selon son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une question </returns>
        internal FindQuestionsDto GetQuestions(int id)
        {
            Question question = questionsRepository.Find(id);
            if (question.IdQuestion == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            FindQuestionsDto questionDto = TransformsModelToDTO(question);
            return questionDto;
        }

        internal List<Question> GetQuestionQuizz(int idLevels,int idCategory,int nombreQuestion)
        {
            return questionsRepository.GenererQuestionQuizz(idLevels, idCategory, nombreQuestion);
        }

        /// <summary>
        /// Supprime la question correspondant à l'id donné
        /// </summary>
        /// <param name="id"></param>
        /// <returns>"1" si tout c'est bien passé, "0" sinon </returns> 
        internal int DeleteQuestion(int id)
        {
            Question question = this.questionsRepository.Find(id);
            int idAnswer = (int)question.IdAnswer;
            int reussi = questionsRepository.Delete(id);
            AnswerServices.Delete(idAnswer);
            return reussi;
        }

        /*
        /// <summary>
        /// Permet d'update une question
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns>une question modifié (DTO) </returns>
        internal FindQuestionsDto PutQuestion(int id, CreatedQuestionDTO obj)
        {
            Question questionModels = transformsDtoToModel(obj);
            Question questionUpdate = questionsRepository.Update(id, questionModels);
            return TransformsModelToDTO(questionUpdate);
        }
        */

        /// <summary>
        /// Générer une question dans la bdd
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>la question créée</returns>
        internal FindQuestionsDto PostQuestion(CreatedQuestionDTO obj)
        {
            // Création de la réponse
            
            FindAnswerDto answer = this.AnswerServices.PostAnswer(obj.Answer);

            // Création de la question
            Question questionModel = transformsDtoToModel(obj, (int)answer.IdAnswer);
            Question questioncreated = questionsRepository.Create(questionModel);

            return TransformsModelToDTO(questioncreated, answer);
        }

        /// <summary>
        /// Permet de transformer un DTO en Model
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>une question en Models </returns>
        private Question transformsDtoToModel(CreatedQuestionDTO obj, int idAnswer)
        {
            return new Question(null,obj.Intitule, obj.IdCategory, obj.IdLevel, idAnswer) ;
        }

        /// <summary>
        /// Converti un Model en DTO
        /// </summary>
        /// <param name="question"></param>
        /// <returns>Une question en DTO</returns>
        private FindQuestionsDto TransformsModelToDTO(Question question, FindAnswerDto answer = null)
        {
            LevelRepository lvlRepo = new LevelRepository(new QueryBuilder());
            CategoryRepository catRepo = new CategoryRepository(new QueryBuilder());
            // Si answer est inconnu alors aller le récupérer à l'aide de service answer et rappel la méthode
            if(answer == null)
            {
                return TransformsModelToDTO(question, AnswerServices.GetAnswerById((int)question.IdAnswer));
            }
            return new FindQuestionsDto(
                question.IdQuestion,
                question.Intitule,
                catRepo.Find((int)question.IdCategory).NameCategory,
                lvlRepo.Find((int)question.IdLevel).NameLevel,
                answer
            );
        }
    }
}
