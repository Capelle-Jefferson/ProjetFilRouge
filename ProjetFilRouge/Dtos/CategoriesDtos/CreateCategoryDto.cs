using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.CategoriesDtos
{
    public class CreateCategoryDto
    {
        public string NameCategory { get; set; }

        public CreateCategoryDto(string nameCategory)
        {
            this.NameCategory = nameCategory;
        }

        public CreateCategoryDto() { }

    }
}
