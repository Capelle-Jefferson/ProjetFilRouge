﻿using ProjetFilRouge.Dtos.AnswerDtos;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using ProjetFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;

namespace ProjetFilRouge.Services
{
    public class AnswerServices
    {
        private AnswerRepository AnswerRepository;

        public AnswerServices()
        {
            AnswerRepository = new AnswerRepository(new QueryBuilder());
        }

        /// <summary>
        ///     Retourne une liste de Levels
        /// </summary>
        /// <returns></returns>
        public List<FindAnswerDto> GetAnswers()
        {
            List<Answer> answers = AnswerRepository.FindAll();
            List<FindAnswerDto> levelsDto = new List<FindAnswerDto>();
            foreach (Answer answer in answers)
            {
                levelsDto.Add(TransformModelToDto(answer));
            }
            return levelsDto;
        }

        /// <summary>
        ///    Permet de transformer un DTO en Model
        /// </summary>
        /// <param name="CreateAnswerRepository"></param>
        /// <returns></returns>
        private Answer TransformDtoToModel(CreateAnswerDto ans)
        {
            return new Answer(null, ans.TypeAnswer, ans.Explication, ans.TextAnswer);
        }

        /// <summary>
        ///     Retourne un Answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal FindAnswerDto GetAnswerById(int id)
        {
            Answer ans = AnswerRepository.Find(id);
            if(ans.IdAnswer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return TransformModelToDto(ans);
        }

        /// <summary>
        ///    Permet de transformer un Model en DTO
        /// </summary>
        /// <param name="Model answer"></param>
        /// <returns></returns>
        private FindAnswerDto TransformModelToDto(Answer ans)
        {
            return new FindAnswerDto(ans.IdAnswer, ans.TypeAnswer, ans.Explication, ans.TextAnswer);
        }

        /// <summary>
        ///     Crée un answer
        /// </summary>
        /// <param name="CreateAnswerRepository"></param>
        /// <returns></returns>
        internal FindAnswerDto PostAnswer(CreateAnswerDto value)
        {
            Answer levelModel = TransformDtoToModel(value);
            Answer levelCreated = this.AnswerRepository.Create(levelModel);
            return TransformModelToDto(levelCreated);
        }

        /// <summary>
        ///     Mets à jour un Answer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CreateAnswerRepository"></param>
        /// <returns></returns>
        internal FindAnswerDto PutAnswer(int id, CreateAnswerDto ans)
        {
            Answer answerModel = TransformDtoToModel(ans);
            Answer answerUpdated = this.AnswerRepository.Update(id, answerModel);
            return TransformModelToDto(answerUpdated);
        }

        /// <summary>
        ///     Permet de supprimer un Answer
        /// </summary>
        /// <param name="id"></param>
        internal int Delete(int id)
        {
            return this.AnswerRepository.Delete(id);
        }
    }
}