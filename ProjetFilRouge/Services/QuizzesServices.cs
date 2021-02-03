using Newtonsoft.Json;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using ProjetTest.Models;

namespace ProjetFilRouge.Services
{
    public class QuizzesServices
    {
        private const int ID_JUNIOR = 1;
        private const int ID_CONFIRME = 2;
        private const int ID_EXPERT = 3;


        private QuizzRepository quizzRepository;
        public QuizzesServices()
        {
            quizzRepository = new QuizzRepository(new QueryBuilder());
        }

        public List<FindQuizzDto> GetQuizzes()
        {
            List<Quizz> quizzes = quizzRepository.FindAll();
            List<FindQuizzDto> quizzesDtos = new List<FindQuizzDto>();
            foreach (Quizz quizz in quizzes)
            {
                quizzesDtos.Add(TransformModelToDto(quizz));
            }
            return quizzesDtos;
        }

        public FindQuizzDto GetQuizzById(int id)
        {
            Quizz quizz = quizzRepository.Find(id);
            return TransformModelToDto(quizz);
        }
        public FindQuizzDto GenerateQuizz(int nbreQuestion, int idLevel, int idCategory)
        {
            string key = TransformeIdLevelToString(idLevel);
            double nbreQuestionJunior = Math.Round(nbreQuestion * Double.Parse(ConfigurationManager.AppSettings.Get(key + "_junior")));
            double nbreQuestionConfirme = Math.Round(nbreQuestion * Double.Parse(ConfigurationManager.AppSettings.Get(key + "_confirme")));
            double nbreQuestionExpert = Math.Round(nbreQuestion * Double.Parse(ConfigurationManager.AppSettings.Get(key + "_expert")));

            QuestionsRepository repoQuestion = new QuestionsRepository(new QueryBuilder());
            List<Question> questions = new List<Question>();
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_JUNIOR, idCategory, (int)nbreQuestionJunior));
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_CONFIRME, idCategory, (int)nbreQuestionConfirme));
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_EXPERT, idCategory, (int)nbreQuestionExpert));
            

            throw new NotImplementedException();
        }



        private FindQuizzDto TransformModelToDto(Quizz quizz)
        {
            CategoryRepository repoCat = new CategoryRepository(new QueryBuilder());
            LevelRepository repoLev = new LevelRepository(new QueryBuilder());
            return new FindQuizzDto(
                quizz.idQuizz,
                quizz.codeQuizz,
                quizz.date,
                repoCat.Find((int)quizz.idCategory).NameCategory,
                repoLev.Find((int)quizz.idLevel).NameLevel,
                quizz.idUser,
                quizz.idCandidate
                );
        }

        public string TransformeIdLevelToString(int id)
        {
            LevelRepository repo = new LevelRepository(new QueryBuilder());
            return repo.Find(id).NameLevel;
        }
    }
}
