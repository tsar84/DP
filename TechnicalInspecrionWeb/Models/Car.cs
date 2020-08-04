using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalInspecrionWeb.Models
{
    public class Car
    {
        [Display(Name = "Ид")]

        [Key]
        public int CarId { get; set; }

        [Display(Name = "Регистрационный номер")]
        public string StateNumber { get; set; }
        //public bool Enabled { get; set; }

        [Display(Name = "Марка")]
        public string Mark { get; set; }

        [Display(Name = "Модель")]
        public string Model { get; set; }

        [Display(Name = "Дата окончания тех.осмотра")]
        public DateTime TechnicalInspectionEndDate { get; set; }

        [Display(Name = "Дата окончания страхового свидетельства")]
        public DateTime InsuranseEndDate { get; set; }

        //public ICollection<TechInspection> TechInspections { get; set; }


    }
}
