﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
            
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };


            #region dataToView
            // viewResult.ViewData.Model

            // ViewData["Movie"] = movie;  --> modo lixo de enviar dada pra view
            // ViewBag.Movie = movie; --> modo lixo de enviar dada pra view
            #endregion  

            var customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Allan Passos"
                },
                new Customer
                {
                    Name = "Guilherme Okubo"
                },
                new Customer
                {
                    Name = "Kawana Okubo"
                },
                new Customer
                {
                    Name = "Nikolas Okubo"
                },
                new Customer
                {
                    Name = "Yasmim Okubo"
                }
            };

            //var viewModel = new RandomMovieViewModel
            //{
            //    Customers = customers,             
            //};


            return View("");




            //return Content("teste");
            // return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home", new { page =1, sortBy = "name" });

        }

        public ActionResult Edit(int id)
        {

            return Content("id=" + id);
        }
        public ViewResult Index()
        {
            //var movies = GetMovies();


            var movies = _context.Movies.Include(m => m.Genre).ToList();


            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.GenreId == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){ Id= 1, Name="Sparta" }, new Movie{ Id=2, Name="Mr.Robot" }
            };

        }


        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0} && sortBy={1}", pageIndex, sortBy));

        //}
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}