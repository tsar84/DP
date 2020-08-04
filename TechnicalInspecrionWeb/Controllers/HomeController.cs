using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechnicalInspecrionWeb.Data;
using TechnicalInspecrionWeb.Models;

namespace TechnicalInspecrionWeb.Controllers
{
    public class HomeController : Controller
    {
        
        
        
        
        
        
        
        
        
        
        
        private readonly ILogger<HomeController> _logger;

        ApplicationDbContext db;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
       
        
        //}

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }







        //public IActionResult Index()
        //{
        //    return View();
        //}





        [Authorize]
        public IActionResult Index()
        {

            return View(db.Cars);

        }

        //менял 27072020
        //[Authorize]
        //public IActionResult Index()
        //{
        //    return Content(User.Identity.Name);

        //}


        //public IActionResult Index(string returnUrl)
        //{

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();

        //}






        [Authorize]
        public IActionResult Privacy()
        {
            return View(db.Drivers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
