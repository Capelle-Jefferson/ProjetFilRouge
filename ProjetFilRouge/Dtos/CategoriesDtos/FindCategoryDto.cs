﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos
{
    public class FindCategoryDto
    {
        public int? IdCategory { get; set; }
        public string NameCategory { get; set; } 

        public FindCategoryDto(string nameCategory, int? idCategory = null)
        {
            this.IdCategory = idCategory;
            this.NameCategory = nameCategory;
        }
    }
}
