using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Models.Faktura, ViewModels.FakturaVM>().ReverseMap();
            CreateMap<Models.FakturaStavke, ViewModels.FakturaStavkaVM>().ReverseMap();

        }
    }
}
