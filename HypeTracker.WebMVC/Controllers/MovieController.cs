using HypeTracker.Data;
using HypeTracker.Data.Classes;
using HypeTracker.Models.MovieModels;
using HypeTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HypeTracker.WebMVC.Controllers
{
    public class MovieController : Controller
    {
        // GET: All Movies
        public ActionResult AllMovies()
        {
            MovieService service = new MovieService();
            IEnumerable<MovieListItem> allMovies = service.GetAllMovies();

            return View(allMovies);
        }

        //public ActionResult FranchisesGenres()
        //{
        //    MovieService service = new MovieService();
        //    List<string> genres = service.GetGenres();

        //    return View(genres);
        //}

        public ActionResult Search(string title)
        {
            MovieService service = new MovieService();
            IEnumerable<MovieListItem> movieSearch = service.GetMoviesByTitle(title);

            return View(movieSearch);
        }

        // GET: Create Movie
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not add movie, please make sure all fields are filled");
                return View(model);
            }

            MovieService service = new MovieService();

            if (service.CreateMovie(model))
            {
                TempData["SaveResult"] = $"{model.Title} was added successfully!";
                return RedirectToAction("AllMovies");
            }

            return View(model);
        }

        // GET: Movie Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MovieService service = new MovieService();
            MovieDetail movie = service.GetMovieById(id);

            return View(movie);

        }

        // GET: Delete Movie
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            MovieService service = new MovieService();
            MovieDetail movie = service.GetMovieById(id);

            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            MovieService service = new MovieService();

            service.DeleteMovie(id);

            return RedirectToAction("AllMovies");
        }

        // GET: Edit Movie
        public ActionResult Edit(int? id)
        {
            MovieService service = new MovieService();
            MovieDetail detail = service.GetMovieById(id);

            MovieEdit movie = new MovieEdit()
            {
                Id = detail.Id,
                Title = detail.Title,
                Description = detail.Description,
                ReleaseDate = detail.ReleaseDate,
                Franchise = detail.Franchise,
                AnticipationValue = detail.AnticipationValue
            };

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Could not update movie, try again later");
                return View(model);
            }

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
            }

            MovieService service = new MovieService();

            if (service.UpdateMovie(model))
            {
                TempData["SaveResult"] = $"{model.Title} was updated";
                return RedirectToAction("AllMovies");
            }

            ModelState.AddModelError("", "Could not update movie, try again later");
            return View(model);
        }
    }
}