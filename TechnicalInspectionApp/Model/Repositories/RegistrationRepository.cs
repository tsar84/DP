using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalInspectionApp.Model.EF;
using TechnicalInspectionApp.Model.Entities;

namespace TechnicalInspectionApp.Model.Repositories
{
  public  class RegistrationRepository
    {

        public List<Registration> GetRegistrations()
        {
            List<Registration> regs = new List<Registration>();


            using (EfDbContext context = new EfDbContext())
            {
                

                regs = context.Registrations.Where(x => x.Enabled).ToList();

               

            }
            return regs;


        }
        public void AddRegistration(Registration reg)
        {
            using (EfDbContext context = new EfDbContext())
            {
                var item = context.Registrations.Where(x => x.UserId == reg.UserId).FirstOrDefault();
                if (item != null)
                {
                    item.Login = reg.Login;
                    item.Password = reg.Password;
                    
                }
                else
                {
                    context.Registrations.Add(reg);
                }
                context.SaveChanges();
            }
        }

        public void DeleteRegistration(Registration reg)
        {
            using (EfDbContext context = new EfDbContext())
            {
                var item = context.Registrations.Where(x => x.UserId == reg.UserId).FirstOrDefault();
                if (item != null)
                {
                    item.Enabled = false;

                    //item.Login = null;
                    //item.Password = null;


                    context.SaveChanges();
                }
            }
        }
    }


}

