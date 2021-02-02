using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.LevelDtos
{
    public class CreateLevelDto
    {
        public string NameLevel { get; set; }

        public CreateLevelDto(string nameLevel)
        {
            this.NameLevel = nameLevel;
        }

        public CreateLevelDto() { }
    }
}
