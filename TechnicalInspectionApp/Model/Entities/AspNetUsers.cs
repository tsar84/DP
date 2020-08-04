using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalInspectionApp.Model.Entities
{
    class AspNetUsers
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public string PasswordHash { get; set; }


    }
}
