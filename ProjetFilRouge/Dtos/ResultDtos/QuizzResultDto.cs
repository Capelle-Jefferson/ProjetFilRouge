using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRouge.Dtos.ResultDtos
{
    public class QuizzResultDto
    {
        public QuizzResultDto() { }
        public QuizzResultDto(double result, double resultJunior, double resultConfirme, double resultExpert,
                              double resultJuniorTotal, double resultConfirmeTotal, double resultExpertTotal)
        {
            ResultTotal = result;
            ResultJunior = resultJunior;
            ResultJuniorTotal = resultJuniorTotal;
            ResultConfirme = resultConfirme;
            ResultConfirmeTotal = resultConfirmeTotal;
            ResultExpert = resultExpert;
            ResultExpertTotal = resultExpertTotal;
        }

        public double ResultTotal { get; set; }
        public double ResultJunior { get; set; }
        public double ResultJuniorTotal { get; set; }

        public double ResultConfirme { get; set; }
        public double ResultConfirmeTotal { get; set; }

        public double ResultExpert { get; set; }
        public double ResultExpertTotal { get; set; }

    }
}
