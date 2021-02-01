using ProjetFilRouge.Dtos.QuestionsDtos;
using ProjetFilRouge.Utils;
using ProjetTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Services
{
    public class QuestionsServices
    {
        Repositories.QuestionsRepository questionsRepository;


        public QuestionsServices ()
            {
            this.questionsRepository = new Repositories.QuestionsRepository(new QueryBuilder());
            }

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

        internal FindQuestionsDto GetQuestions(int id)
        {
            Question question = questionsRepository.Find(id);
            FindQuestionsDto questionDto = TransformsModelToDTO(question);
            return questionDto;
        }

        private FindQuestionsDto TransformsModelToDTO(Question question)
        {
            return new FindQuestionsDto(question.IdQuestion,question.Intitule,question.IdCategory,question.IdLevel,question.IdAnswer);
        }
    }
}
