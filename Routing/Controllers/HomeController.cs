using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Diagnostics;

namespace Routing.Controllers
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

		public IActionResult Privacy()
		{
			return View();
		}


		public IActionResult Catchall(){

			return View();

		}

		public IActionResult Chicken(){

			return Redirect("https://www.chick-fil-a.com/");

		}

		public IActionResult Default(int moo){

			return Content($"The Cow moos at you {moo.ToString()}" + " times");

		}

		public IActionResult CowName(int times, string name){

			return Content($"The Cow {name} moos at you {times.ToString()}" + " times");

		}

		public IActionResult Gallery(int perpage){

			return Content($"all the cows featured on our website ╚(•⌂•)╝ <--only the one cow, {perpage.ToString()} cows per page");

		}

		public IActionResult Gallery2(int perpage, int page){

			return Content($"╚(•⌂•)╝, {perpage.ToString()} cows per page, page {page.ToString()}");

		}

		public IActionResult Gallery3(int perpage, int page){

			return Content($"╚(•⌂•)╝, {perpage.ToString()} cows per page, page {page.ToString()}");

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}