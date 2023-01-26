using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers{

    public class HomeController : Controller{

        private readonly ILogger<HomeController> _logger;

        private static int count = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(){

            return View();
        
        }

        public IActionResult Privacy(){

            return View();
        
        }

        public IActionResult RouteTest(int? id, string name){

            return Content($"id={id?.ToString() ?? "NULL"}");

        }

        public IActionResult Colors(string colors){

            var colorList = colors.Split("/");

            return Content(string.Join(",", colorList));

        }

        public IActionResult Counter(){

            ViewBag.Count = count++;

            ViewData["Count"] = ViewBag.Count;

            return View();

        }

		public IActionResult ParamTest(int? ID, string name){ //? means is able to be null

            //return Content("Stuff"); //Content means you can return anything

            return Content($"id = {ID?.ToString() ?? "NULL"}" + "Name: " + $"name = {name}"); 

            // ?? = Null operator, if left is null do right side. --^
            
            // id? = null check, if null no to string --^

            //if multiple paramaters are sent, the priority = 1. Form, 2. Route, 3. query string

		}

		public IActionResult Input(){

            ViewData["Title"] = "Input Form";

            return View();

        }

        public IActionResult Output(string FirstName, string LastName){ //passed have to match the id name I Despise Web

            ViewBag.FN = FirstName;

            ViewBag.LN = LastName;

            return View();

            //return view("Output");

            //return Redirect("any link you want");

        }

        public IActionResult About(){ //Make sure to have one of these to view the page, I fucking hat web!

            return View();
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error(){

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }

    }

}
