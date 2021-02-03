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

namespace ProjetFilRouge.Services
{
    public class QuizzesServices
    {
        private const int ID_JUNIOR = 1;
        private const int ID_CONFIRME = 2;
        private const int ID_EXPERT = 3;
        private const string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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
        public FindQuizzDto GenerateQuizz(CreateQuizzDto createQuizzDto, int nbreQuestion)
        {
            // Récupère le nombre de questions par niveau de difficultés
            string key = TransformeIdLevelToString(createQuizzDto.IdLevel);
            double nbreQuestionJunior = Math.Round(nbreQuestion * Double.Parse(ConfigurationManager.AppSettings.Get(key + "_junior")));
            double nbreQuestionConfirme = Math.Round(nbreQuestion * Double.Parse(ConfigurationManager.AppSettings.Get(key + "_confirme")));
            double nbreQuestionExpert = Math.Round(nbreQuestion * Double.Parse(ConfigurationManager.AppSettings.Get(key + "_expert")));
            double sum = nbreQuestionJunior + nbreQuestionConfirme + nbreQuestionExpert;
            if (sum < nbreQuestion)
                nbreQuestionJunior++;
            else if(sum > nbreQuestion)
                nbreQuestionExpert--;

            // Récupère les questions du quizz
            QuestionsRepository repoQuestion = new QuestionsRepository(new QueryBuilder());
            List<Question> questions = new List<Question>();
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_JUNIOR, createQuizzDto.IdCategory, (int)nbreQuestionJunior));
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_CONFIRME, createQuizzDto.IdCategory, (int)nbreQuestionConfirme));
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_EXPERT, createQuizzDto.IdCategory, (int)nbreQuestionExpert));

            // Creation et enregistrement du quizz
            Quizz quizz = new Quizz(null, GenerateCode(12), null, createQuizzDto.IdCategory, createQuizzDto.IdLevel, createQuizzDto.IdUser, createQuizzDto.IdCandidat);
            quizz = quizzRepository.Create(quizz);

            // Enregistrement des questions du quizz
            PersisteQuizzQuestion(questions, quizz);

            return TransformModelToDto(quizz);
        }

        private void PersisteQuizzQuestion(List<Question> questions, Quizz quizz)
        {
            QuizzQuestionRepository questionQuizzRepo = new QuizzQuestionRepository(new QueryBuilder());
            foreach (Question question in questions)
            {
                QuizzQuestion quizzQuestion = new QuizzQuestion((int)quizz.idQuizz, (int)question.IdQuestion, "");
                questionQuizzRepo.Create(quizzQuestion);
            }
        }

        public string GenerateCode(int n)
        {
            Random rd = new Random();
            String code = "";
            for (int i = 0; i<n; i++)
            {
                code += ALPHABET[rd.Next(0,ALPHABET.Count())];
            }
            if (IsAlreadyExist(code))
                return GenerateCode(n);
            return code;
        }

        public bool IsAlreadyExist(string code)
        {
            Quizz quizz = quizzRepository.FindByCode(code);
            return quizz.idQuizz != null;
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
