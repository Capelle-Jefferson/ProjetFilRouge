﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Models
{
    public class Candidate
    {
        public int? idCandidate { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int? idUser { get; set; }
        public int? idLevel { get; set; }

        public Candidate(int? idCandidate, string firstname, string lastname, string email, int? idUser, int? idLevel)
        {
            this.idCandidate = idCandidate;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.idUser = idUser;
            this.idLevel = idLevel;
        }

        public Candidate()
        {
        }
    }
}
