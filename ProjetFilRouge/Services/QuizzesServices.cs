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
using ProjetFilRouge.Dtos.ResultDtos;
using ProjetFilRouge.Dtos.QuizzQDTO;

namespace ProjetFilRouge.Services
{
    public class QuizzesServices
    {
        private const int ID_JUNIOR = 1;
        private const int ID_CONFIRME = 2;
        private const int ID_EXPERT = 3;
        private const string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private QuizzRepository quizzRepository;
        private QuizzQuestionService quizzQuestionService;
        private AnswerServices AnswersServices;

        public QuizzesServices(QuizzRepository quizzRepository, QuizzQuestionService quizzQuestionService, AnswerServices answerServices)
        {
            this.quizzRepository = quizzRepository;
            this.quizzQuestionService = quizzQuestionService;
            this.AnswersServices = answerServices;
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
        /// Correction des réponses dans les quizz
        /// </summary>
        /// <param name="id"></param>
        internal void GetGoodAnswersQuizz(int id)
        {
            this.quizzRepository.UpdateDateQuizz(id);
            //Récupération du quizz
            FindQuizzDto quizz = this.GetQuizzById(id);
            //Instance d'une liste vide de strings si QCM Multiple et un string vide si QCM
            List<string> tableauGoodAnswer=new List<string>();
            string goodUniqueAnswer = "";
            //Correction questions par questions
            foreach (FindQuizzQuestionsDto question in quizz.Questions)
            {
                if (question.Answer.TypeAnswer == "QCM_multiple")
                {
                    tableauGoodAnswer= correctAnswers(question);// on récupère la list des bonnes réponses
                    List<string> candidatAnswers = question.CandidateAnswer.Split('§').ToList(); // On découpe la réponse du candidat en séparant avec le §
                    if(CompareAnswers(candidatAnswers,tableauGoodAnswer)){
                       this.quizzQuestionService.AddIsCorrectAnswer(id, (int)question.IdQuestion, 1);//Si la réponse est exacte alors c'est "true"
                    }else
                    {
                       this.quizzQuestionService.AddIsCorrectAnswer(id, (int)question.IdQuestion, 0);
                    }
                }else if(question.Answer.TypeAnswer == "QCM")
                {
                    foreach(FindChoiceAnswerDto choiceAnswer in question.Answer.ListChoiceAnswer)
                    {
                        if (choiceAnswer.IsAnswer == true)
                        {
                            goodUniqueAnswer = choiceAnswer.TextAnswer; // On récupère la bonne réponse dans la bdd
                        }
                    }
                    if (CompareUniqueAnswer(question.CandidateAnswer, goodUniqueAnswer)) //On compare les réponses si c'est un QCM choix multiple
                    {
                        this.quizzQuestionService.AddIsCorrectAnswer(id, (int)question.IdQuestion, 1);//Si la réponse est exacte alors c'est "true"
                    }
                    else
                    {
                        this.quizzQuestionService.AddIsCorrectAnswer(id, (int)question.IdQuestion, 0);
                    }
                }
            }
           
        }

        public bool CompareAnswers(List<string> candidatAnswers, List<string> goodAnswers)
        {
            int compteur = 0;
            foreach(string answer in candidatAnswers)
            {
                if (goodAnswers.Contains(answer))
                {
                    compteur++;
                }
            }
            return (compteur.Equals(goodAnswers.Count));
            
        }
        /// <summary>
        /// Comparaison de deux strings 
        /// </summary>
        /// <param name="candidatAnswers"></param>
        /// <param name="goodAnswers"></param>
        /// <returns>bool</returns>
        public bool CompareUniqueAnswer(string candidatAnswers,string goodAnswers)
        {
            return (candidatAnswers.Equals(goodAnswers));
        }
        /// <summary>
        /// Récupération de toutes les bonnes réponses dans le cas d'un qcm à choix multiple
        /// </summary>
        /// <param name="question"></param>
        /// <returns> une liste de strings </returns>
        public List<string> correctAnswers(FindQuizzQuestionsDto question)
        {
            List<string> goodAnswers =new List<string>() ;
            foreach (FindChoiceAnswerDto choiceAnswer in question.Answer.ListChoiceAnswer)
            {
                if (choiceAnswer.IsAnswer == true)
                {
                    goodAnswers.Add(choiceAnswer.TextAnswer);
                }
            }

            return goodAnswers;
        }
        /// <summary>
        /// Recuperation des quizz d'un candidat
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une list de quizz</returns>
        internal List<FindQuizzDto> GetQuizzByCandidateId(int id)
        {
            List<Quizz> quizzes = quizzRepository.FindByCandidateId(id);
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
        public FindQuizzCandidateDto GetQuizzByIdInProgress(string code)
        {
            Quizz quizz = quizzRepository.Find(code);
            FindQuizzCandidateDto quizzDto = TransformModelToDtoCandidate(quizz);
            foreach (FindQuizzQuestionCandidateDto q in quizzDto.Questions.ToList())
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
            double nbreQuestionExpert = nbreQuestion - nbreQuestionJunior - nbreQuestionConfirme;

            // Récupère les questions du quizz
            QuestionsRepository repoQuestion = new QuestionsRepository(new QueryBuilder());
            List<Question> questions = new List<Question>();
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_JUNIOR, createQuizzDto.IdCategory, (int)nbreQuestionJunior));
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_CONFIRME, createQuizzDto.IdCategory, (int)nbreQuestionConfirme));
            questions.AddRange(repoQuestion.GenererQuestionQuizz(ID_EXPERT, createQuizzDto.IdCategory, (int)nbreQuestionExpert));

            // Creation et enregistrement du quizz
            Quizz quizz = new Quizz(null, GenerateCode(12), null, createQuizzDto.IdCategory, createQuizzDto.IdLevel, createQuizzDto.IdUser, createQuizzDto.IdCandidate);
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
                QuizzQuestion quizzQuestion = new QuizzQuestion((int)quizz.idQuizz, (int)question.IdQuestion, "", null);
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
        ///     Transforme le model d'un quizz en dto pour un candidat, sans les réponses
        /// </summary>
        /// <param name="quizz">Quizz à transformer</param>
        /// <returns>FindQuizzCandidateDto</returns>
        private FindQuizzCandidateDto TransformModelToDtoCandidate(Quizz quizz)
        {
            CategoryRepository repoCat = new CategoryRepository(new QueryBuilder());
            LevelRepository repoLev = new LevelRepository(new QueryBuilder());
            QuizzQuestionRepository quizzQRepo = new QuizzQuestionRepository(new QueryBuilder());
            return new FindQuizzCandidateDto(
                quizz.idQuizz,
                quizz.codeQuizz,
                quizz.date,
                repoCat.Find((int)quizz.idCategory).NameCategory,
                repoLev.Find((int)quizz.idLevel).NameLevel,
                quizz.idUser,
                quizz.idCandidate,
                ReturnQuestionsCandidateQuizz(quizzQRepo.FindAll((int)quizz.idQuizz))
                );
        }

        /// <summary>
        ///     Récupérations des questions composant le quizz pour un candidat
        /// </summary>
        /// <param name="questionsQuizz">liste de QuizzQuestion</param>
        /// <returns>List<FindQuizzQuestionsCandidateDto></returns>
        private List<FindQuizzQuestionCandidateDto> ReturnQuestionsCandidateQuizz(List<QuizzQuestion> questionsQuizz)
        {
            QuestionsRepository questionRepo = new QuestionsRepository(new QueryBuilder());
            List<FindQuizzQuestionCandidateDto> questionsDtos = new List<FindQuizzQuestionCandidateDto>();
            foreach (QuizzQuestion quizzQ in questionsQuizz)
            {
                Question question = questionRepo.Find((int)quizzQ.IdQuestion);
                questionsDtos.Add(TransformsModelToDTOQuestionCandidate(question, quizzQ.AnswerCandidate, quizzQ.IsCorrectAnswer));
            }
            return questionsDtos;
        }
        private FindQuizzQuestionCandidateDto TransformsModelToDTOQuestionCandidate(Question question, string answerCandidate, bool? isCorrectAnswer)
        {
            CategoryRepository catRepo = new CategoryRepository(new QueryBuilder());
            FindAnswerCandidateDto answer = AnswersServices.GetAnswerByIdCandidate((int)question.IdAnswer);
            return new FindQuizzQuestionCandidateDto(
                question.IdQuestion,
                question.Intitule,
                catRepo.Find((int)question.IdCategory).NameCategory,
                TransformeIdLevelToString((int)question.IdLevel),
                answer,
                answerCandidate,
                isCorrectAnswer
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
                questionsDtos.Add(TransformsModelToDTOQuestion(question, quizzQ.AnswerCandidate, quizzQ.IsCorrectAnswer));
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
        private FindQuizzQuestionsDto TransformsModelToDTOQuestion(Question question, string answerCandidate, bool?isCorrectAnswer)
        {
            CategoryRepository catRepo = new CategoryRepository(new QueryBuilder());
            FindAnswerDto answer = AnswersServices.GetAnswerById((int)question.IdAnswer);
            return new FindQuizzQuestionsDto(
                question.IdQuestion,
                question.Intitule,
                catRepo.Find((int)question.IdCategory).NameCategory,
                TransformeIdLevelToString((int)question.IdLevel),
                answer,
                answerCandidate,
                isCorrectAnswer
            ) ;
        }

        public int DeleteByIdQuizz(int id)
        {
            quizzQuestionService.DeleteQuizzQ(id);
            return this.quizzRepository.Delete(id);
        }

        /// <summary>
        ///     Retourne le resultat d'un quizz
        /// </summary>
        /// <param name="idQuizz">id du quizz</param>
        /// <returns>QuizzResultDto</returns>
        public QuizzResultDto GetQuizzResult(int idQuizz)
        {
            FindQuizzDto quizz = this.GetQuizzById(idQuizz);

            // Dictionnaire, key: nom du niveau (junior,..) et
            // en valeur le nbre de question total du niveau et le nbre de bonne réponse dans ce niveau
            Dictionary<string, (int, int)> results = new Dictionary<string, (int, int)>();
            results.Add("junior", (0, 0));
            results.Add("confirme", (0, 0));
            results.Add("expert", (0, 0));

            foreach (FindQuizzQuestionsDto question in quizz.Questions)
            {
                string key = question.Level;
                if (results.ContainsKey(key))
                {
                    int nbCorrect = results[key].Item2;
                    if ((bool)question.IsCorrectAnswer)
                        nbCorrect++;
                    results[key] = (results[key].Item1 + 1, nbCorrect) ;
                }
            }
            return CalculResult(results);
        }
        /// <summary>
        ///     Calcule et retourne le resultat d'un quizz
        /// </summary>
        /// <param name="results">
        ///     Dictionnaire, key: nom du niveau (junior,..) et 
        ///     en valeur le nbre de question total du niveau et le nbre de bonne réponse dans ce niveau 
        /// </param>
        /// <returns>Resultat du quizz</returns>
        private QuizzResultDto CalculResult(Dictionary<string, (int, int)> results)
        {
            // Calcule du pourcentage de bonne reponse de chaque niveau
            double junior = -1;
            if(results["junior"].Item1 != 0)
                junior = ((double)results["junior"].Item2 / results["junior"].Item1) * 100;

            double confirme = -1;
            if (results["confirme"].Item1 != 0)
                confirme = ((double)results["confirme"].Item2 / results["confirme"].Item1)*100;

            double expert = -1;
            if (results["expert"].Item1 != 0)
                expert = ((double)results["expert"].Item2 / results["expert"].Item1)*100;

            // Calcule du pourcentage total
            double nbQuestions = results["junior"].Item1 + results["confirme"].Item1 + results["expert"].Item1;
            double nbCorrectQuestion = results["junior"].Item2 + results["confirme"].Item2 + results["expert"].Item2;
            double total = (nbCorrectQuestion / nbQuestions)*100;

            double juniorTotal = ((double)results["junior"].Item1 / nbQuestions) * 100;
            double confirmeTotal = ((double)results["confirme"].Item1 / nbQuestions) * 100;
            double expertTotal = ((double)results["expert"].Item1 / nbQuestions) * 100;

            return new QuizzResultDto(
                Math.Round(total,2),
                Math.Round(junior,2),
                Math.Round(confirme, 2),
                Math.Round(expert, 2),
                Math.Round(juniorTotal, 2),
                Math.Round(confirmeTotal, 2),
                Math.Round(expertTotal, 2)
            );
        }
    }
}
