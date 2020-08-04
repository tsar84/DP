using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInspectionApp.Model.Entities
{
   public class Registration
    {
        [Key]
        public int UserId { get; set; }
        public string Login { get; set; }
        public bool Enabled { get; set; }
        public string Password { get; set; }
        

    }
}
