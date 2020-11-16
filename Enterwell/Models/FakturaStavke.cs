using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell.Models
{
    public class FakturaStavke
    {
        public int FakturaStavkeID { get; set; }
        public string opisProdaneStavke { get; set; }

        public int kolicinaProdaneStavke { get; set; }

        public float jedinicnaCijenaStavkeBezPoreza { get; set; }

        public float ukupnaCijenaZaStavkuBezPoreza { get; set; }


        public int fakturaID { get; set; }
        public virtual Faktura faktura { get; set; }


    }
}
