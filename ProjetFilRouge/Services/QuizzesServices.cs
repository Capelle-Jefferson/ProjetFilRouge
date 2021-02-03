using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Services
{
    public class QuizzesServices
    {
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
    }
}
