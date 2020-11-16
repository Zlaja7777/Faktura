using System;
using System.Collections.Generic;
using System.Text;
using Enterwell.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Enterwell.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Faktura> Faktura { get; set; }
        public DbSet<FakturaStavke> FakturaStavka { get; set; }

    }
}
