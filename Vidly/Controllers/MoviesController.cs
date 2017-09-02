
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
      

        public MoviesController()
        {
            _context = new ApplicationDbContext();
           

        }

        public ViewResult Index()
        {

    

            var movies = _context.Movie.Include(c => c.Genre).ToList();


            // var movies2 = _context.Movies.ToList();

            return View(movies);

        }

        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genres
            };



            return View("CustomerForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).FirstOrDefault(m => m.GenreId == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movie.SingleOrDefault(c => c.Id == id);

            var genres = _context.Genres.ToList();

            if (movies == null)
                return HttpNotFound();


            var viewModel = new MovieFormViewModel()
            {
                Movie = movies,
                Genre = _context.Genres.ToList()
            };


            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (movie.Id == 0)
                _context.Movie.Add(movie);          
            else
            {
                var movieInDb = _context.Movie.Single(c => c.Id == movie.Id);

                #region Notas - AutoMapper
                //TryUpdateModel(customerInDb); //abordagem ruim, porem, oficial da MS.
                //aqui entraria um automapper pra fazer isso com uma linha só 
                //Mapper.Map(customer, customerInDb);
#endregion
                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                Console.WriteLine(ex);
            }


            return RedirectToAction("Index", "Movies");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}