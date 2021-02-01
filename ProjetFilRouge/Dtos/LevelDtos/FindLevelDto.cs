using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos
{
    public class FindLevelDto
    {
        public int? IdLevel { get; set; }
        public string NameLevel { get; set; }
        public FindLevelDto(int? idLevel, string nameLevel)
        {
            this.IdLevel = idLevel;
            this.NameLevel = nameLevel;
        }
    }
}
