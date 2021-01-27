using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Level
    {
        public int? idLevel { get; set; }
        public string nameLevel { get; set; }
        public Level(int? idLevel,string nameLevel)
        {
            this.idLevel = idLevel;
            this.nameLevel = nameLevel;
        }
    }
}
