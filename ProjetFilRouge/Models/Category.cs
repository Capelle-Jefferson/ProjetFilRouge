using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Category
    {
        public int? idCategory { get; set; }
        public string nameCategory { get; set; } 

        public Category(int? idCategory,string nameCategory)
        {
            this.idCategory = idCategory;
            this.nameCategory = nameCategory;
        }

        public Category()
        {
        }
    }
}
