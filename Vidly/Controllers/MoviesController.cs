using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _contex;
        public MoviesController()
        {
            _contex = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }
        public ActionResult Index()
        {
            if(User.IsInRole("CanManageMovies"))
                 return View("List");
            return View("ReadOnlyList");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {
            var genres = _contex.Genres.ToList();
            var viewModel = new MovieFormView
            {
                Genres = genres,

            };
            return View("FormMovie", viewModel);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Update(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormView(movie)
                {
                    
                    Genres = _contex.Genres.ToList(),

                };
                return View("FormMovie",viewModel);

            }    
               

            if(movie.Id == 0)
            {
                _contex.Movies.Add(movie);
            }    
            else
            {
                var movieDb = _contex.Movies.Single(m => m.Id == movie.Id);
                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.DateAdded = movie.DateAdded;
                movieDb.GenreId = movie.GenreId;
            }
            _contex.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _contex.Movies.Single(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormView(movie)
            {
                Genres = _contex.Genres.ToList(),
             
            };
            return View("FormMovie", viewModel);

        }
    }
}