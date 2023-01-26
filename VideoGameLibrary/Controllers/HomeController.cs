using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers{

	public class HomeController : Controller{

		private static List<Game> gamesList = new List<Game> {

			new Game("Dead By Daylight", "Pc, Playstation, nintendo, & ios", "Horror", "M", 2016, "debbie.jpg", null, null),

			new Game("Chinese Parents", "Pc, nintendo, ios, & android", "Indie", "E", 2018, "cParents.jpg", null, null),

			new Game("Minecraft", "Pc, nintendo, playstation, xbox, ios, & android", "Survival", "E", 2011, "mCraft.png", null, null),

			new Game("Space Engineers", "Pc, & xbox", "Space", "T", 2019, "spaceEng.jpg", null, null),

			new Game("Yandere Simulator", "Pc", "Simulation", "M", 2014, "ySim.png", null, null)

		};

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger){

			_logger = logger;
		
		}

		public IActionResult Index(){

			return View();
		
		}

		[HttpGet]

		public IActionResult Collection(){

			ViewBag.ammountGam = gamesList.Count;

			return View(gamesList);
		
		}

		[HttpPost]

		public IActionResult Collection(int? id, string LoanedTo){

			DateTime time = DateTime.Now;

			Game aGame = gamesList.Find(game => game.Id == id);

			aGame.LoanedTo = LoanedTo;

			aGame.LoanedDate = time;

			return View(gamesList);
		
		}

		[HttpPost]
		public IActionResult loanGam(int? id){

            Game aGame = gamesList.Find(game => game.Id == id);

            aGame.LoanedTo = null;

            aGame.LoanedDate = null;

            return RedirectToAction("Collection", "Home");
		
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}