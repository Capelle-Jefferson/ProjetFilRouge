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

        public FindCategoryDto GetCategoryById(int id)
        {
            Category cat = categoryRepository.Find(id);
            return TransformModelToDto(cat);
        }

        public FindCategoryDto PostCategory(CreateCategoryDto cat)
        {
            Category categoryModel = TransformDtoToModel(cat);
            Category categoryCreated = this.categoryRepository.Create(categoryModel);
            return TransformModelToDto(categoryCreated);
        }

        public int Delete(int id)
        {
            return this.categoryRepository.Delete(id);
        }

        public FindCategoryDto PutCategory(int id, CreateCategoryDto cat)
        {
            Category categoryModel = TransformDtoToModel(cat);
            Category categoryUpdated = this.categoryRepository.Update(id, categoryModel);
            return TransformModelToDto(categoryUpdated);
        }

        private Category TransformDtoToModel(CreateCategoryDto cat)
        {
            return new Category(null, cat.NameCategory);
        }

        private FindCategoryDto TransformModelToDto(Category cat)
        {
            return new FindCategoryDto(cat.NameCategory, cat.IdCategory);
        }
    }
}
