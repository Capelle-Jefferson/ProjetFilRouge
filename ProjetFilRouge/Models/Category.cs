using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Category
    {
        public int? IdCategory { get; set; }
        public string NameCategory { get; set; } 

        public Category(int? idCategory,string nameCategory)
        {
            this.IdCategory = idCategory;
            this.NameCategory = nameCategory;
        }

        public Category()
        {
        }
    }
}
