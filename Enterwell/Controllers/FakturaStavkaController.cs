using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterwell.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Enterwell.ViewModels;
using Enterwell.Models;

namespace Enterwell.Controllers
{
    public class FakturaStavkaController : Controller
    {

        private IFakturaStavka IFakturaStavka;

       
   
        public FakturaStavkaController(IFakturaStavka fakturaStavka)
        {
            IFakturaStavka = fakturaStavka;
       
        }
        public IActionResult AddForm(int fakturaID)
        {
            FakturaStavkaVM model = new FakturaStavkaVM();
            model.fakturaID = fakturaID;
            return View(model);
        }
        public IActionResult Save(FakturaStavkaVM fm)
        {
            IFakturaStavka.Add(fm);   
            return RedirectToAction("FakturaDetails", "Faktura", new { id = fm.fakturaID });
        }
     


    }
}
