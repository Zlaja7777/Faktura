using Enterwell.Data;
using Enterwell.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Enterwell.ViewModels;
using AutoMapper;
using Enterwell.Models;

namespace Enterwell.Services
{
    public class FakturaStavkaService : IFakturaStavka
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext db;
        
        public FakturaStavkaService(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
        
            mapper = _mapper;
        }
        public List<FakturaStavkaVM> GetAll(int? fakturaID)
        {
            var list  = db.FakturaStavka.Where(w=>w.fakturaID == fakturaID).ToList();
            return mapper.Map<List<FakturaStavkaVM>>(list);
        }
        public void Add(FakturaStavkaVM fm)
        {
            FakturaStavke f = new FakturaStavke();
            fm.ukupnaCijenaZaStavkuBezPoreza = fm.kolicinaProdaneStavke * fm.jedinicnaCijenaStavkeBezPoreza;
            f =  mapper.Map<FakturaStavke>(fm);
            db.Add(f);
            db.SaveChanges();
        }
        //public FakturaVM GetById(string uid, int ?id)
        //{
            
        //    if(id != null)
        //    {
        //        var model = db.Faktura.Where(w=> w.FakturaID == id).FirstOrDefault();
        //        return mapper.Map<FakturaVM>(model);

        //    }
        //    else
        //    {
        //        var model = db.Faktura.Where(w => w.korisnikID == uid).OrderByDescending(o => o.FakturaID).FirstOrDefault();
        //        return mapper.Map<FakturaVM>(model);
        //    }
            
        //}
    }
}
