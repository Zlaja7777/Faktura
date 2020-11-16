using Enterwell.Models;
using Enterwell.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell.Interfaces
{
    public interface IFaktura
    {
        List<ViewModels.FakturaVM> GetAll(string k);
        void Add(FakturaVM fm, string userId);
        FakturaVM GetById(string uid, int ?id);
        void Update(int fakturaID);
    }
}
