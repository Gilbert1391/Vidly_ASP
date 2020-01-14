using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Movies")]
        public ActionResult Index()
        {
            ICollection<Movie> movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(new MoviesViewModel { Movies = movies });
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("Movies/New")]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            ViewBag.Title = "New Movie";

            return View("MovieForm", new MovieFormViewModel { Genres = genres });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Movies/Save")]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("MovieForm", new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                });
            }

            if (movie.Id == 0)
            {
                 movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Route("Movies/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            ViewBag.Title = "Edit Movie";

            return View("MovieForm", new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            });
        }

    }
}