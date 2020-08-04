using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechnicalInspecrionWeb.Models;

namespace TechnicalInspecrionWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        //public DbSet<TechInspection> TechInspections { get; set; }
        //public DbSet<Report> Reports { get; set; }

        public DbSet<Registration> Registrations { get; set; }

    }
}
