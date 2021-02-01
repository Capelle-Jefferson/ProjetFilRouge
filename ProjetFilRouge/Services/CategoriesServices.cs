using ProjetFilRouge.Dtos;
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

        internal FindCategoryDto GetCategoryById(int id)
        {
            Category cat = categoryRepository.Find(id);
            return TransformModelToDto(cat);
        }



        private Category TransformDtoToModel(FindCategoryDto cat)
        {
            return new Category(cat.IdCategory, cat.NameCategory);
        }

        private FindCategoryDto TransformModelToDto(Category cat)
        {
            return new FindCategoryDto(cat.nameCategory, cat.idCategory);
        }
    }
}
