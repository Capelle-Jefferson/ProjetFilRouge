using ProjetFilRouge.Dtos;
using ProjetFilRouge.Dtos.LevelDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Services
{
    public class LevelServices
    {
        private LevelRepository LevelRepository;
        public LevelServices()
        {
            LevelRepository = new LevelRepository(new QueryBuilder());
        }

        /// <summary>
        ///     Retourne une liste de Levels
        /// </summary>
        /// <returns></returns>
        public List<FindLevelDto> GetLevels()
        {
            List<Level> levels = LevelRepository.FindAll();
            List<FindLevelDto> levelsDto = new List<FindLevelDto>();
            foreach (Level level in levels)
            {
                levelsDto.Add(TransformModelToDto(level));
            }
            return levelsDto;
        }

        /// <summary>
        ///    Permet de transformer un DTO en Model
        /// </summary>
        /// <param name="CreateLevelDto"></param>
        /// <returns></returns>
        private Level TransformDtoToModel(CreateLevelDto lev)
        {
            return new Level(null, lev.NameLevel);
        }

        /// <summary>
        ///     Retourne un Level
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal FindLevelDto GetLevelById(int id)
        {
            Level lev = LevelRepository.Find(id);
            return TransformModelToDto(lev);
        }

        /// <summary>
        ///    Permet de transformer un Model en DTO
        /// </summary>
        /// <param name="Model level"></param>
        /// <returns></returns>
        private FindLevelDto TransformModelToDto(Level lev)
        {
            return new FindLevelDto(lev.IdLevel, lev.NameLevel);
        }

        /// <summary>
        ///     Crée un level
        /// </summary>
        /// <param name="CreateLevelDto"></param>
        /// <returns></returns>
        internal FindLevelDto PostLevel(CreateLevelDto value)
        {
            Level levelModel = TransformDtoToModel(value);
            Level levelCreated = this.LevelRepository.Create(levelModel);
            return TransformModelToDto(levelCreated);
        }

        /// <summary>
        ///     Mets à jour un Level
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CreateLevelDto"></param>
        /// <returns></returns>
        internal FindLevelDto PutLevel(int id, CreateLevelDto lev)
        {
            Level levelModel = TransformDtoToModel(lev);
            Level levelUpdated = this.LevelRepository.Update(id, levelModel);
            return TransformModelToDto(levelUpdated);
        }

        /// <summary>
        ///     Permet de supprimer un Level
        /// </summary>
        /// <param name="id"></param>
        internal int Delete(int id)
        {
            return this.LevelRepository.Delete(id);
        }
    }
}