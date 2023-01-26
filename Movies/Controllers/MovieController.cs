using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Movies.Models;

namespace Movies.Controllers{

    public class MovieController : Controller{

        private static List<Movie> MovieList = new List<Movie> {

            new Movie("A Monster in Paris", 2011, 3.5f),

            new Movie("Transformers: Dark of the Moon", 2011, 1.0f),

            new Movie("Real Steel", 2011, 4.5f)

        };

        public IActionResult Index(){

            return View();
        
        }

		public IActionResult MultMovies(){

			return View(MovieList);

		}

        [HttpGet] //loading create page

		public IActionResult Create(){

			return View();

		}

        [HttpGet]

        public IActionResult Edit(int? Id){

			if(Id == null){

                return NotFound();
            
            }

            Movie foundMovie = MovieList.Where(m => m.Id == Id).FirstOrDefault();

            if(foundMovie == null) { 
                
                return NotFound(); 
            
            }

            return View(foundMovie);

		}

		[HttpPost]

		public IActionResult Edit(Movie m){

            int i;

            i = MovieList.FindIndex(x => x.Id == m.Id);

            MovieList[i] = m;

            TempData["success"] = "Movie " + m.Title + " Updated";

            return RedirectToAction("MultMovies", "Movie");

		}

        [HttpGet]

		public IActionResult Delete(int? Id){

            int i;

            i = MovieList.FindIndex(x => x.Id == Id);

			MovieList.RemoveAt(i);

			TempData["success"] = "Movie Removed";

            return RedirectToAction("MultMovies", "Movie");

		}

		[HttpPost] //saving create page

		public IActionResult Create(Movie m){

            if(ModelState.IsValid) { 

                MovieList.Add(m); // adds movie to list aparently 

                TempData["success"] = "Movie created";

                return RedirectToAction("MultMovies", "Movie");

			}else{

                return View();

            }

		}

		public IActionResult MovieDiplay(){

            Movie movie = new Movie("Rango", 2011, 3.5f);
            
            return View(movie);

        }

    }

}
