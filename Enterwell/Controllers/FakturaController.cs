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
    public class FakturaController : Controller
    {

        private IFaktura IFaktura;
        private IFakturaStavka IFakturaStavka;


        private readonly UserManager<IdentityUser> userManager;
        public FakturaController(IFaktura _IFaktura, UserManager<IdentityUser> _userManager, IFakturaStavka fakturaStavka)
        {
            IFaktura = _IFaktura;
            userManager = _userManager;
            IFakturaStavka = fakturaStavka;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                var model = IFaktura.GetAll(user.Id);
                return View("Home", model);
            }
           
            return View("Home");
            
          
        }
        public IActionResult AddForm()
        {
            FakturaVM model = new FakturaVM();

            return View(model);
        }
        public async Task<IActionResult> Save(FakturaVM fm)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            IFaktura.Add(fm, user.Id);
            
            return RedirectToAction("FakturaDetails");
        }
        public async Task<IActionResult> FakturaDetails(int ?id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var model = IFaktura.GetById(user.Id, id);
            List<FakturaStavkaVM> fm = IFakturaStavka.GetAll(id);
            ViewData["stavke"] = fm;
            return View(model);
        }

        public IActionResult Update(int fakturaID)
        {

            IFaktura.Update(fakturaID);

            return RedirectToAction("FakturaDetails", new { id = fakturaID });
        }
        //public IActionResult AddStavku()
        //{
        //    return View();
        //}
        //public IActionResult SaveStavku()
        //{
        //    return View();
        //}
        //public IActionResult GetStavke()
        //{
        //    return View();
        //}
    }
}
