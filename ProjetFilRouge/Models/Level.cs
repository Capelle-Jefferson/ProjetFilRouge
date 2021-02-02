﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Level
    {
        public int? IdLevel { get; set; }
        public string NameLevel { get; set; }
        public Level(int? idLevel,string nameLevel)
        {
            this.IdLevel = idLevel;
            this.NameLevel = nameLevel;
        }

        public Level() { }
    }
}
