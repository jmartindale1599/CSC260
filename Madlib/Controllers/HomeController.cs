using Madlib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Madlib.Controllers
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

        public IActionResult Input(){

            return View();
        
        }

        public IActionResult Output(string Noun1, string Verb, string Noun2, string Adject, string Noun3){

            ViewBag.No1 = Noun1;

            ViewBag.Ve = Verb;

            ViewBag.No2 = Noun2;

            ViewBag.Ad = Adject;
            
            ViewBag.No3 = Noun3;

            return View();
        
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