using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell.ViewModels
{
    public class FakturaStavkaVM
    {
     
        public string opisProdaneStavke { get; set; }

        public int kolicinaProdaneStavke { get; set; }

        public float jedinicnaCijenaStavkeBezPoreza { get; set; }

        public float ukupnaCijenaZaStavkuBezPoreza { get; set; }


        public int fakturaID { get; set; }
    }
}
