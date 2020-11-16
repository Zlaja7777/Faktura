using Enterwell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell.Interfaces
{
    public interface IFakturaStavka
    {
        List<FakturaStavkaVM> GetAll(int? k);
        void Add(FakturaStavkaVM fm);
        
    }
}
