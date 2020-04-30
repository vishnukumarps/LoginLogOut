using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginLogOut.Models;
using Microsoft.AspNetCore.Http;
namespace LoginLogOut.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {

            ViewBag.Email = HttpContext.Session.GetString("Email");
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string pass)
        {

            HttpContext.Session.SetString("Email", email);

            return RedirectToAction("Success");
        }


       
        public IActionResult LogOut()
        {

            HttpContext.Session.Clear();
            

            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
