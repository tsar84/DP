using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalInspecrionWeb.Models
{
    public class Driver
    {
        [Display(Name = "Ид")]

        [Key]
        public int DriverId { get; set; }
        
        [Display(Name = "Ф.И.О.")]
        public string FIO { get; set; }
        
        public bool Enabled { get; set; }
        [Display(Name = "Дата выдачи водительского удостоверения")]
        public string DriverLicenseData { get; set; }
        [Display(Name = "Дата окончания водительского удостоварения")]
        public DateTime DriverLicenseEndDate { get; set; }

        //public ICollection<TechInspection> TechInspections { get; set; }




    }
}
