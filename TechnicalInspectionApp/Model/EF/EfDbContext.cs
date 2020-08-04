using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInspectionApp.Model.Entities;

namespace TechnicalInspectionApp.Model.EF
{
    class EfDbContext : DbContext
    {
        //public EfDbContext() : base("DBConnection")


         public EfDbContext() : base("DefaultConnection")
        
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<TechInspection> TechInspections { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<AspNetUsers> AspNetUsers { get; set; }


    }
}
