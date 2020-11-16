using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell.ViewModels
{
    public class FakturaVM
    {
        public int fakturaID { get; set; }
        public int brojFakture { get; set; }
        public DateTime datumStvaranjaFakture { get; set; }
        public DateTime datumDospijecaFakture { get; set; }

        public float cijenaBezPoreza { get; set; }
        public float cijenaSaPorezom { get; set; }

        public string korisnikID { get; set; }
        public string primateljRacuna { get; set; }
    }
}
