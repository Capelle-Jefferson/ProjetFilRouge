using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.ResultDtos
{
    public class QuizzResultDto
    {
        public QuizzResultDto() { }
        public QuizzResultDto(double result, double resultJunior, double resultConfirme, double resultExpert)
        {
            ResultTotal = result;
            ResultJunior = resultJunior;
            ResultConfirme = resultConfirme;
            ResultExpert = resultExpert;
        }

        public double ResultTotal { get; set; }
        public double ResultJunior { get; set; }
        public double ResultConfirme { get; set; }
        public double ResultExpert { get; set; }

    }
}
