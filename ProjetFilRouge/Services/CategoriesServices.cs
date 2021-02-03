using HttpExceptions.Exceptions;
using ProjetFilRouge.Dtos;
using ProjetFilRouge.Dtos.CategoriesDtos;
using ProjetFilRouge.Models;
using ProjetFilRouge.Repositories;
using ProjetFilRouge.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Services
{
    public class CategoriesServices
    {
        private CategoryRepository categoryRepository;
        public CategoriesServices()
        {
            categoryRepository = new CategoryRepository(new QueryBuilder());
        }

        /// <summary>
        /// Récupération de toutes les catégories
        /// </summary>
        /// <returns>List<Category></returns>
        public List<FindCategoryDto> GetCategories()
        {
            List<Category> categories = categoryRepository.FindAll();
            List<FindCategoryDto> cetegoriesDto = new List<FindCategoryDto>();
            foreach (Category cat in categories)
            {
                cetegoriesDto.Add(TransformModelToDto(cat));
            }
            return cetegoriesDto;
        }

        /// <summary>
        /// Récupération de la catégorie dont l'identifiant est id 
        /// </summary>
        /// <param name="id">identifiant de la catégorie recherché</param> 
        /// <returns>Category</returns>
        public FindCategoryDto GetCategoryById(int id)
        {
            Category cat = categoryRepository.Find(id);
            if (cat.IdCategory == null)
                throw new NotFoundException("not found");
            return TransformModelToDto(cat);
        }

        /// <summary>
        /// Persister la categorie cat 
        /// </summary>
        /// <param name="cat">la catégorie à persister</param>
        /// <returns>Categorie</returns>
        public FindCategoryDto PostCategory(CreateCategoryDto cat)
        {
            Category categoryModel = TransformDtoToModel(cat);
            Category categoryCreated = this.categoryRepository.Create(categoryModel);
            return TransformModelToDto(categoryCreated);
        }

        /// <summary>
        /// Supprimer la catégorie dont l'identifiant est id
        /// </summary>
        /// <param name="id">identifiant de la categorie à supprimer</param>
        /// <returns>1 si la catégorie à bien était supprimé, 0 sinon</returns>
        public int Delete(int id)
        {
            return this.categoryRepository.Delete(id);
        }

        /// <summary>
        /// Modifier la catégorie dont l'identifiant est id
        /// </summary>
        /// <param name="id">identifiant</param>
        /// <param name="cat">la nouvelle catégorie</param>
        /// <returns>Categorie</returns>
        public FindCategoryDto PutCategory(int id, CreateCategoryDto cat)
        {
            Category categoryModel = TransformDtoToModel(cat);
            Category categoryUpdated = this.categoryRepository.Update(id, categoryModel);
            return TransformModelToDto(categoryUpdated);
        }

        /// <summary>
        /// Transforme un createdCategorie DTO en model 
        /// </summary>
        /// <param name="cat">le createCategoryDto</param>
        /// <returns>Categorie</returns>
        private Category TransformDtoToModel(CreateCategoryDto cat)
        {
            return new Category(null, cat.NameCategory);
        }

        /// <summary>
        /// Transforme une Catgorie en Find DTO
        /// </summary>
        /// <param name="cat">La catégorie</param>
        /// <returns>FindCategoryDto</returns>
        private FindCategoryDto TransformModelToDto(Category cat)
        {
            return new FindCategoryDto(cat.NameCategory, cat.IdCategory);
        }
    }
}
