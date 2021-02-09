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
using ProjetFilRouge.Dtos.QuestionsDtos;
using ProjetFilRouge.Dtos.AnswerDtos;

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

        /// <summary>
        ///     Recupération de la liste des quizzes
        /// </summary>
        /// <returns>List<FindQuizzDto></returns>
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

        /// <summary>
        ///     Récupération d'un quizz en cour, uniquement les questions qui n'ont pas était complété
        /// </summary>
        /// <param name="id">identitfiant du quizz à récupérer</param>
        /// <returns>FindQuizzDto</returns>
        public FindQuizzDto GetQuizzByIdInProgress(int id)
        {
            Quizz quizz = quizzRepository.Find(id);
            FindQuizzDto quizzDto = TransformModelToDto(quizz);
            foreach (FindQuizzQuestionsDto q in quizzDto.Questions.ToList())
            {
                if(q.CandidateAnswer != null)
                {
                    quizzDto.Questions.Remove(q);
                }
            }
            return quizzDto;
        }

        /// <summary>
        ///     Récupération d'un quizz
        /// </summary>
        /// <param name="id">identitfiant du quizz à récupérer</param>
        /// <returns>FindQuizzDto</returns>
        public FindQuizzDto GetQuizzById(int id)
        {
            Quizz quizz = quizzRepository.Find(id);
            return TransformModelToDto(quizz);
        }

        /// <summary>
        ///     Génère un quizz
        /// </summary>
        /// <param name="createQuizzDto">Objetc quizz à créer</param>
        /// <param name="nbreQuestion">Nombre de questions composant le quizz</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Remplis la table QuizzQuestion en associant chaque question du quizz
        /// </summary>
        /// <param name="questions">Listes des questions du quizz</param>
        /// <param name="quizz">le quizz</param>
        private void PersisteQuizzQuestion(List<Question> questions, Quizz quizz)
        {
            QuizzQuestionRepository questionQuizzRepo = new QuizzQuestionRepository(new QueryBuilder());
            foreach (Question question in questions)
            {
                QuizzQuestion quizzQuestion = new QuizzQuestion((int)quizz.idQuizz, (int)question.IdQuestion, "");
                questionQuizzRepo.Create(quizzQuestion);
            }
        }

        /// <summary>
        ///     Génère un code aléatoire
        /// </summary>
        /// <param name="n">Nombre de caractères à générer</param>
        /// <returns>code aléatoire</returns>
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

        /// <summary>
        ///     Vérifie si un quizz ne possède pas déjà ce même code
        /// </summary>
        /// <param name="code">code du quizz à vérifier</param>
        /// <returns>true si le code est déjà utilisé, false sinon</returns>
        public bool IsAlreadyExist(string code)
        {
            Quizz quizz = quizzRepository.FindByCode(code);
            return quizz.idQuizz != null;
        }

        /// <summary>
        ///     Transforme le model d'un quizz en dto
        /// </summary>
        /// <param name="quizz">Quizz à transformer</param>
        /// <returns>FindQuizzDto</returns>
        private FindQuizzDto TransformModelToDto(Quizz quizz)
        {
            CategoryRepository repoCat = new CategoryRepository(new QueryBuilder());
            LevelRepository repoLev = new LevelRepository(new QueryBuilder());
            QuizzQuestionRepository quizzQRepo = new QuizzQuestionRepository(new QueryBuilder());
            return new FindQuizzDto(
                quizz.idQuizz,
                quizz.codeQuizz,
                quizz.date,
                repoCat.Find((int)quizz.idCategory).NameCategory,
                repoLev.Find((int)quizz.idLevel).NameLevel,
                quizz.idUser,
                quizz.idCandidate,
                ReturnQuestionsQuizz(quizzQRepo.FindAll((int)quizz.idQuizz))
                );
        }

        /// <summary>
        ///     Récupérations des questions composant le quizz
        /// </summary>
        /// <param name="questionsQuizz">liste de QuizzQuestion</param>
        /// <returns>List<FindQuizzQuestionsDto></returns>
        private List<FindQuizzQuestionsDto> ReturnQuestionsQuizz(List<QuizzQuestion> questionsQuizz)
        {
            QuestionsRepository questionRepo = new QuestionsRepository(new QueryBuilder());
            List<FindQuizzQuestionsDto> questionsDtos = new List<FindQuizzQuestionsDto>();
            foreach (QuizzQuestion quizzQ in questionsQuizz)
            {
                Question question = questionRepo.Find((int)quizzQ.IdQuestion);
                questionsDtos.Add(TransformsModelToDTOQuestion(question, quizzQ.IdAnswerCandidate));
            }
            return questionsDtos;
        }

        /// <summary>
        ///     Transforme l'id level par son nom
        /// </summary>
        /// <param name="id">identifiant de Level</param>
        /// <returns>son du level</returns>
        public string TransformeIdLevelToString(int id)
        {
            LevelRepository repo = new LevelRepository(new QueryBuilder());
            return repo.Find(id).NameLevel;
        }

        /// <summary>
        ///     Trasnforme une question en FindQuizzQuestionsDto
        /// </summary>
        /// <param name="question">question à transformer</param>
        /// <param name="idAnswerCandidate">id de la réponse du candidat</param>
        /// <returns>FindQuizzQuestionsDto</returns>
        private FindQuizzQuestionsDto TransformsModelToDTOQuestion(Question question, int? idAnswerCandidate)
        {
            CategoryRepository catRepo = new CategoryRepository(new QueryBuilder());
            AnswerServices answerServices = new AnswerServices();
            FindAnswerDto answer = answerServices.GetAnswerById((int)question.IdAnswer);
            FindAnswerDto candidateAnswer = idAnswerCandidate == null ? null : answerServices.GetAnswerById((int)idAnswerCandidate);
            return new FindQuizzQuestionsDto(
                question.IdQuestion,
                question.Intitule,
                TransformeIdLevelToString((int)question.IdLevel),
                catRepo.Find((int)question.IdLevel).NameCategory,
                answer,
                candidateAnswer
            ) ;
        }

        public int DeleteByIdQuizz(int id)
        {
            QuizzQuestionService quizzQservices = new QuizzQuestionService();
            quizzQservices.DeleteQuizzQ(id);
            return this.quizzRepository.Delete(id);
        }
    }
}
