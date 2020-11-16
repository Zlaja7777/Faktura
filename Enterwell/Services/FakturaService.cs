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
    public class FakturaService : IFaktura
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext db;
        
        public FakturaService(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
        
            mapper = _mapper;
        }
        public List<FakturaVM> GetAll(string k)
        {
            var list  = db.Faktura.Where(w=>w.korisnikID == k).ToList();
            return mapper.Map<List<FakturaVM>>(list);
        }
        public void Add(FakturaVM fm, string userId)
        {
            fm.korisnikID = userId;
            Faktura f = new Faktura();
            f =  mapper.Map<Faktura>(fm);
            db.Add(f);
            db.SaveChanges();
            
        }
        public FakturaVM GetById(string uid, int ?id)
        {
            
            if(id != null)
            {
                var model = db.Faktura.Where(w=> w.FakturaID == id).FirstOrDefault();
                return mapper.Map<FakturaVM>(model);

            }
            else
            {
                var model = db.Faktura.Where(w => w.korisnikID == uid).OrderByDescending(o => o.FakturaID).FirstOrDefault();
                return mapper.Map<FakturaVM>(model);
            }
            
        }
        public void Update(int fakturaID)
        {
            Faktura f = db.Faktura.Find(fakturaID);
            List<FakturaStavke> fs = db.FakturaStavka.Where(w => w.fakturaID == fakturaID).ToList();
            float sum = 0;
            foreach (var i in fs)
            {
                sum += i.ukupnaCijenaZaStavkuBezPoreza;
            }
            f.cijenaBezPoreza = sum;
            f.cijenaSaPorezom = f.cijenaBezPoreza + (float)(0.17 * f.cijenaBezPoreza);
            //ne znam je li se na ukupnu cijenu racuna porez ili svaku stavku
            db.Update(f);
            db.SaveChanges();
        }
    }
}
